    ArrayList notIdenticalList = new ArrayList(); 
            DirectorySecurity parentFolderAccessControl = Directory.GetAccessControl(null);
            DirectorySecurity childItemAccessControl = Directory.GetAccessControl(null);
            foreach (FileSystemAccessRule parentRule in parentFolderAccessControl.GetAccessRules(true, true, typeof(NTAccount)))
            {
                foreach (FileSystemAccessRule childRule in childItemAccessControl.GetAccessRules(true, true, typeof(NTAccount)))
                {
                    if (parentRule.FileSystemRights != childRule.FileSystemRights)
                    {
                        // add to not identical-list
                        notIdenticalList.Add(fileToAdd...);
                        break;
                    }
                }
            }
