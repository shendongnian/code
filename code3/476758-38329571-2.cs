    class Program
        {  
            [DllImport("namEm.DLL", CallingConvention = CallingConvention.Cdecl, EntryPoint = "nameEm", 
                CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern int nameEm([MarshalAs(UnmanagedType.LPStr)] StringBuilder str);
            static void Main(string[] args)
            {
                int m = 3;
                StringBuilder str = new StringBuilder();
                str.Append(String.Format("{0};", m));
                str.Append(String.Format("{0} {1:E4};", 5, 76.334E-3 ));
                str.Append(String.Format("{0} {1} {2} {3};", 65,45,23,12));
                m = nameEm(str);
            }
        }
