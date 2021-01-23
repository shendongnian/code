	namespace DeepCopy {
		public static class ObjectExtensions {
			public static T[] Copy<T>(this T[] pieces) {
				return pieces.Select(x => {
					var handle=Marshal.AllocHGlobal(Marshal.SizeOf(typeof(T)));
					try {
						Marshal.StructureToPtr(x, handle, false);
						return (T)Marshal.PtrToStructure(handle, typeof(T));
					}
					finally {
						Marshal.FreeHGlobal(handle);
					}
				}).ToArray();
			}
		}
	}
