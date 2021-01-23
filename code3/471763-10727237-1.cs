    using System;
    using System.Runtime.InteropServices;
    using System.Text;
    
    public class _Main
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetLongPathName(
            string path,
            StringBuilder longPath,
            int longPathLength
            );
            
        public static void Main()
        {
            StringBuilder longPath = new StringBuilder(255);
            GetLongPathName(@"\\?\UNC\server\d$\MYTEMP~1\RESOUR~1\sql.txt", longPath, longPath.Capacity);
            Console.WriteLine(longPath.ToString());
        }
    }
