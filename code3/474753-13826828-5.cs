	using System;
	using System.Reflection.Emit;
	using System.Runtime.InteropServices;
	public class Voodoo<T> where T : class
	{
		static readonly IntPtr tptr;
		static readonly int tsize;
		static readonly byte[] zero;
		
		public static T NewInUnmanagedMemory()
		{
			IntPtr handle = Marshal.AllocHGlobal(tsize);
			Marshal.Copy(zero, 0, handle, tsize);
			IntPtr ptr = handle+4;
			Marshal.WriteIntPtr(ptr, tptr);
			return GetO(ptr);
		}
		
		public static void FreeUnmanagedInstance(T obj)
		{
			IntPtr ptr = GetPtr(obj);
			IntPtr handle = ptr-4;
			Marshal.FreeHGlobal(handle);
		}
		
		delegate T GetO_d(IntPtr ptr);
		static readonly GetO_d GetO;
		delegate IntPtr GetPtr_d(T obj);
		static readonly GetPtr_d GetPtr;
		static Voodoo()
		{
			Type t = typeof(T);
			tptr = t.TypeHandle.Value;
			tsize = Marshal.ReadInt32(tptr, 4);
			zero = new byte[tsize];
			
			DynamicMethod m = new DynamicMethod("GetO", typeof(T), new[]{typeof(IntPtr)}, typeof(Voodoo<T>), true);
			var il = m.GetILGenerator();
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ret);
			GetO = m.CreateDelegate(typeof(GetO_d)) as GetO_d;
			
			m = new DynamicMethod("GetPtr", typeof(IntPtr), new[]{typeof(T)}, typeof(Voodoo<T>), true);
			il = m.GetILGenerator();
			il.Emit(OpCodes.Ldarg_0);
			il.Emit(OpCodes.Ret);
			GetPtr = m.CreateDelegate(typeof(GetPtr_d)) as GetPtr_d;
		}
	}
