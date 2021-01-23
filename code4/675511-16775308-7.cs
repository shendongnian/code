        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetLongPathName(
            string path,
            StringBuilder longPath,
            int longPathLength
            );
        /// <summary>
        /// Return true if file exists. Non case sensitive by default.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="caseSensitive"></param>
        /// <returns></returns>
        public static bool FileExists(string filename, bool caseSensitive = false)
        {
            if (!File.Exists(filename))
            {
                return false;
            }
            if (!caseSensitive)
            {
                return true;
            }
       
            //check case
            StringBuilder longPath = new StringBuilder(255);
            GetLongPathName(Path.GetFullPath(filename), longPath, longPath.Capacity);
            string realPath = Path.GetDirectoryName(longPath.ToString());
            return Array.Exists(Directory.GetFiles(realPath), s => s == filename);
        }
