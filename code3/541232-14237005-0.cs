       void GetTree(string strSearchPath)
            {
                treeFiles.Nodes.Clear();
                SetNode(treeFiles, strSearchPath);
                treeFiles.TopNode.Expand();
            }
    
            void SetNode(TreeView treeName, string path)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);
                TreeNode node = new TreeNode(dirInfo.Name);
                node.Tag = dirInfo;
                GetFolders(dirInfo, node);
                GetFiles(dirInfo, node);
                treeName.Nodes.Add(node);
            }
    
            void GetFolders(DirectoryInfo d, TreeNode node)
            {
    
                try
                {
                    DirectoryInfo[] dInfo = d.GetDirectories();
    
                    if (dInfo.Length > 0)
                    {
                        TreeNode treeNode = new TreeNode();
                        foreach (DirectoryInfo driSub in dInfo)
                        {
                            treeNode = node.Nodes.Add(driSub.Name, driSub.Name, 0, 0);
                            GetFiles(driSub, treeNode);
                            GetFolders(driSub, treeNode);
                        }
                    }
                }
                catch (Exception ex) { }
    
            }
    
            void GetFiles(DirectoryInfo d, TreeNode node)
            {
                var files = d.GetFiles("*.doc*");
                FileInfo[] subfileInfo = files.ToArray<FileInfo>();
    
                if (subfileInfo.Length > 0)
                {
                    for (int j = 0; j < subfileInfo.Length; j++)
                    {
                        bool isHidden = ((File.GetAttributes(subfileInfo[j].FullName) & FileAttributes.Hidden) == FileAttributes.Hidden);
                        if (!isHidden)
                        {
                            string strExtention = Path.GetExtension(subfileInfo[j].FullName);
                            if (strExtention.Contains("doc"))
                            {
                                TreeNode treeNode = new TreeNode();
                                string path = subfileInfo[j].FullName;
                                string name = subfileInfo[j].Name;
                                treeNode = node.Nodes.Add(path, name, 1, 1);
                                AddBookMarkFile(path, treeNode);
                            }
                        }
                    }
                }
            }
