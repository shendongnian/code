	using System;
	using System.Reflection.Emit;
	using System.Runtime.InteropServices;
	public class ObjectHandle<T> : IDisposable where T : class
	{
		bool freed;
		readonly IntPtr handle;
		readonly T value;
		readonly IntPtr tptr;
		
		public ObjectHandle() : this(typeof(T))
		{
			
		}
		
		public ObjectHandle(Type t)
		{
			tptr = t.TypeHandle.Value;
			int size = Marshal.ReadInt32(tptr, 4);//base instance size
			handle = Marshal.AllocHGlobal(size);
			byte[] zero = new byte[size];
			Marshal.Copy(zero, 0, handle, size);//zero memory
			IntPtr ptr = handle+4;
			Marshal.WriteIntPtr(ptr, tptr);//write type ptr
			value = GetO(ptr);//convert to reference
		}
		
		public T Value{
			get{
				return value;
			}
		}
		
		public bool Valid{
			get{
				return Marshal.ReadIntPtr(handle, 4) == tptr;
			}
		}
		
		public void Dispose()
		{
			if(!freed)
			{
				Marshal.FreeHGlobal(handle);
				freed = true;
				GC.SuppressFinalize(this);
			}
		}
		
		~ObjectHandle()
		{
			Dispose();
		}
		
		delegate T GetO_d(IntPtr ptr);
		static readonly GetO_d GetO;
		static ObjectHandle()
		{
			DynamicMethod m = new DynamicMethod("GetO", typeof(T), new[]{typeof(IntPtr)}, typeof(ObjectHandle<T>), true);
			var il = m.GetILGenerator();
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ret);
			GetO = m.CreateDelegate(typeof(GetO_d)) as GetO_d;
		}
	}
	/*Usage*/
	using(var handle = new ObjectHandle<MyClass>())
	{
		//do some work
	}
