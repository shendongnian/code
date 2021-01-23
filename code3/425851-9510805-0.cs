    [Browsable(false)]
        public Guid[] FrameDimensionsList
        {
          get
          {
            int count;
            int frameDimensionsCount = SafeNativeMethods.Gdip.GdipImageGetFrameDimensionsCount(new HandleRef((object) this, this.nativeImage), out count);
            if (frameDimensionsCount != 0)
              throw SafeNativeMethods.Gdip.StatusException(frameDimensionsCount);
            if (count <= 0)
              return new Guid[0];
            int num1 = Marshal.SizeOf(typeof (Guid));
            IntPtr num2 = Marshal.AllocHGlobal(num1 * count);
            if (num2 == IntPtr.Zero)
              throw SafeNativeMethods.Gdip.StatusException(3);
            int frameDimensionsList = SafeNativeMethods.Gdip.GdipImageGetFrameDimensionsList(new HandleRef((object) this, this.nativeImage), num2, count);
            if (frameDimensionsList != 0)
            {
              Marshal.FreeHGlobal(num2);
              throw SafeNativeMethods.Gdip.StatusException(frameDimensionsList);
            }
            else
            {
              Guid[] guidArray = new Guid[count];
              try
              {
                for (int index = 0; index < count; ++index)
                  guidArray[index] = (Guid) System.Drawing.UnsafeNativeMethods.PtrToStructure((IntPtr) ((long) num2 + (long) (num1 * index)), typeof (Guid));
              }
              finally
              {
                Marshal.FreeHGlobal(num2);
              }
              return guidArray;
            }
          }
        }
