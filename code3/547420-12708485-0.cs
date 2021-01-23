        public static void CopyFileLikeWin7(string pathIn,string fileName, string pathOut)
        {
            string potentialFileName = Path.Combine(pathOut,fileName);
            if(File.Exists(potentialFileName))
            {
                CopyFileLikeWin7(pathIn, Path.GetFileNameWithoutExtension(fileName) + "-copy" + Path.GetExtension(fileName), pathOut);
            }
            else
            {
                File.Copy(pathIn,potentialFileName);
            }
        }
