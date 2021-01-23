    /// <summary>
    /// tests (and creates missing) directories in path containing many 
    subDirectories which might not exist.
        /// </summary>
        /// <param name="FN"></param>
        public static string VerifyPath(string FN, out bool AllOK)
        {
            AllOK = true;
            var dir = FolderUtils.GetParent(FN);
            if (!Directory.Exists(dir))//todo - move to folderUtils.TestFullDirectory
            {
                const char DIR = '\\';
                //string dirDel = "" + DIR;
                string[] subDirs = FN.Split(DIR);
                string dir2Check = "";
                int startFrom = 1;//skip "c:\"
                FN = CleanPathFromDoubleSlashes(FN);
                if (FN.StartsWith("" + DIR + DIR))//netPath
                    startFrom = 3;//FN.IndexOf(DIR, 2);//skip first two slashes..
                for (int i = 0; i < startFrom; i++)
                    dir2Check += subDirs[i] + DIR;//fill in begining
                for (int i = startFrom; i < subDirs.Length - 1; i++)//-1 for the file name..
                {
                    dir2Check += subDirs[i] + DIR;
                    if (!Directory.Exists(dir2Check))
                        try
                        {
                            Directory.CreateDirectory(dir2Check);
                        }
                        catch { AllOK = false; }
                }
            }
            if (File.Exists(FN))
                FN = FolderUtils.getFirstNonExistingPath(FN);
            if (FN.EndsWith("\\") && !Directory.Exists(FN))
                try { Directory.CreateDirectory(FN); }
                catch
                {
                    HLogger.HandleMesssage("couldn't create dir:" + FN, TypeOfExceptions.error, PartsOfSW.FileStructure);
                    AllOK = false;
                }
            return FN;
        }
