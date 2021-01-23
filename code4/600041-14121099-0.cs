            DirectoryInfo diOriginalPath = new DirectoryInfo(strOriginalPath);
            if (diOriginalPath.Attributes.HasFlag(FileAttributes.ReadOnly))
                diOriginalPath.Attributes &= ~FileAttributes.ReadOnly;
            string[] lstFileList = Directory.GetFiles(strOriginalPath);
            string[] lstdirectoryList = Directory.GetDirectories(strOriginalPath);
            if (lstdirectoryList.Length > 0)
            {
                // foreach on the subdirs to the call method recursively
                foreach (string strSubDir in lstdirectoryList)
                    DirectoryDelete(strSubDir);
            }
            if (lstFileList.Length > 0)
            {
                // foreach in FileList to be delete files
                foreach (FileInfo fiFileInDir in lstFileList.Select(strArquivo => new FileInfo(strArquivo)))
                {
                    // removes the ReadOnly attribute
                    if (fiFileInDir.IsReadOnly)
                        fiFileInDir.Attributes &= ~FileAttributes.ReadOnly;
                    // Deleting file
                    fiFileInDir.Delete();
                }
            }
            diOriginalPath.Delete();
        }
