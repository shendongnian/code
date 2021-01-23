    [DllImport("Win32Project1.dll", EntryPoint = "?Save@@YAXPAPAM@Z", CallingConvention = CallingConvention.Cdecl)]
            static extern void Save(IntPtr arr);
    static void Main(string[] args)
            {
    
                float[][] testA = new float[][] { new float[] { 1.0f, 2.0f }, new float[] { 3.0f, 4.0f } };
    
                    IntPtr initArray = Marshal.AllocHGlobal(8);
                    IntPtr arrayAlloc = Marshal.AllocHGlobal(sizeof(float)*4);
    
                    Marshal.WriteInt32(initArray, arrayAlloc.ToInt32());
                    Marshal.WriteInt32(initArray+4, arrayAlloc.ToInt32() + 2 * sizeof(float));
                    Marshal.Copy(testA[0], 0, arrayAlloc, 2);
                    Marshal.Copy(testA[1], 0, arrayAlloc + 2*sizeof(float), 2);
    
                    Save(initArray); // C func call
    
                    Marshal.FreeHGlobal(arrayAlloc);
                    Marshal.FreeHGlobal(initArray);
    
                    Console.ReadLine();
    
            }
