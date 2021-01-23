    using System.Runtime.InteropServices;
    
    public class ActiveNames
    {
        public string[] ActiveNames { get; set; }
    
        [DllImport("GetActiveNames.dll")] // replace with the actual name of the DLL
        unsafe private static int GetActiveNames(sbyte** names):
    
        public void GetActiveNames()
        {
            unsafe
            {
                // I use 100 here as an artificial number. This may not be a reasonable
                // assumption, but I don't know how the actual GetActiveNames works
                sbyte** names = (sbyte**)Marshal.AllocHGlobal(100).ToPointer();
    
                try
                {
                    GetActiveNames(names);
    
                    // fill the ActiveNames property
                    ActiveNames = new string[100];
    
                    for (int i = 0; i < 100; ++i)
                        ActiveNames[i] = new string(names[i]);
                }
                finally
                {
                    // deallocate the unmanaged names memory
                    Marshal.FreeHGlobal(IntPtr((void*)names));
                }
            }
        }
    }
