	public struct ByValArray<T>
	{
		//Backup field for cloning from.
		T[] array;
		
		public ByValArray(int size)
		{
			array = new T[size];
			//Updating the instance is really not necessary until we access it.
		}
		
		private void Update()
		{
			//This should be called from any public method on this struct.
			T[] inst = FindInstance(ref this);
			if(inst != array)
			{
				//A new array was cloned for this address.
				array = inst;
			}
		}
		
		//I suppose a GCHandle would be better than WeakReference,
		//but this is sufficient for illustration.
		static readonly Dictionary<IntPtr, WeakReference<T[]>> Cache = new Dictionary<IntPtr, WeakReference<T[]>>();
		
		static T[] FindInstance(ref ByValArray<T> arr)
		{
			T[] orig = arr.array;
			return UnsafeTools.GetPointer(
				//Obtain the address from the reference.
				//It uses a lambda to minimize the chance of the reference
				//being moved around by the GC.
				out arr,
				ptr => {
					WeakReference<T[]> wref;
					T[] inst;
					if(Cache.TryGetValue(ptr, out wref) && wref.TryGetTarget(out inst))
					{
						//An object is found on this address.
						if(inst != orig)
						{
							//This address was overwritten with a new value,
							//clone the instance.
							inst = (T[])orig.Clone();
							Cache[ptr] = new WeakReference<T[]>(inst);
						}
						return inst;
					}else{
						//No object was found on this address,
						//clone the instance.
						inst = (T[])orig.Clone();
						Cache[ptr] = new WeakReference<T[]>(inst);
						return inst;
					}
				}
			);
		}
		
		//All subsequent methods should always update the state first.
		public T this[int index]
		{
			get{
				Update();
				return array[index];
			}
			set{
				Update();
				array[index] = value;
			}
		}
		
		public int Length{
			get{
				Update();
				return array.Length;
			}
		}
		
		public override bool Equals(object obj)
		{
			Update();
			return base.Equals(obj);
		}
		
		public override int GetHashCode()
		{
			Update();
			return base.GetHashCode();
		}
		
		public override string ToString()
		{
			Update();
			return base.ToString();
		}
	}
----
	var a = new ByValArray<int>(10);
	a[5] = 11;
	Console.WriteLine(a[5]); //11
	
	var b = a;
	b[5]++;
	Console.WriteLine(b[5]); //12
	Console.WriteLine(a[5]); //11
	
	var c = a;
	a = b;
	Console.WriteLine(a[5]); //12
	Console.WriteLine(c[5]); //11
