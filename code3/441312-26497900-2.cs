    using System.IO;
    
    namespace Sapbucket.Common
    {
        public static class FolderSupport
        {
            public static void DeleteFolder(string folderPath, bool recursively)
            {
                DirectoryInfo _directoryInfo;
    
                _directoryInfo = new DirectoryInfo(folderPath);
                _directoryInfo.Refresh();
                if (_directoryInfo.Exists)
                {
                    _directoryInfo.Delete(recursively);
    
                    while (_directoryInfo.Exists)
                        _directoryInfo.Refresh();
                }
            }
        }
    }
