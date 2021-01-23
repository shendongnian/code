        public string GetShortFileName(string fileDirectory, string fileNameWithExtension)
        {
            StringBuilder temp = new StringBuilder(255);
            string path = System.IO.Path.Combine(fileDirectory, fileNameWithExtension);
            int n = GetShortPathName(path, temp, 255);
            if (n == 0)
                throw new NotImplementedException();
            string extension = System.IO.Path.GetExtension(path);
            return ((temp.ToString().Split('\\')).Last()).ToLower();//.Replace(extension, string.Empty);
        }
        [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
                public static extern int GetShortPathName(
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]    
            string path,
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPTStr)]    
            StringBuilder shortPath,
            int shortPathLength);
