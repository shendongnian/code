    using System.IO;
    class MyFolderFileHelper {
        public static bool? FileExistsWithDifferentCase(string fileName)
        {
            bool? result = null;
            if (File.Exists(fileName))
            {
                result = false;
                string directory = Path.GetDirectoryName(fileName);
                string fileTitle = Path.GetFileName(fileName);
                string[] files = Directory.GetFiles(directory, fileTitle);
                if (String.Compare(files[0], fileName, false) != 0)
                    result = true;                
            }
            return result;
        }
        public static bool? DirectoryExistsWithDifferentCase(string directoryName)
        {
            bool? result = null;
            if (Directory.Exists(directoryName))
            {
                result = false;
                directoryName = directoryName.TrimEnd(Path.DirectorySeparatorChar);
                int lastPathSeparatorIndex = directoryName.LastIndexOf(Path.DirectorySeparatorChar);
                if (lastPathSeparatorIndex >= 0)
                {                       
                    string baseDirectory = directoryName.Substring(lastPathSeparatorIndex + 1);
                    string parentDirectory = directoryName.Substring(0, lastPathSeparatorIndex);
                    string[] directories = Directory.GetDirectories(parentDirectory, baseDirectory);
                    if (String.Compare(directories[0], directoryName, false) != 0)
                        result = true;
                }
                else
                {
                    //if directory is a drive
                    directoryName += Path.DirectorySeparatorChar.ToString();
                    DriveInfo[] drives = DriveInfo.GetDrives();
                    foreach(DriveInfo driveInfo in drives)
                    {
                        if (String.Compare(driveInfo.Name, directoryName, true) == 0)
                        {
                            if (String.Compare(driveInfo.Name, directoryName, false) != 0)
                                result = true;
                            break;
                        }
                    }
                }
            }
            return result;
        }
    }
