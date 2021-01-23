        private void button2_Click(object sender, EventArgs e)
        { 
          if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                string strSearchPath=folderBrowserDialog1.SelectedPath;
                GetTree(strSearchPath);
            }
        } 
       void GetTree(string strSearchPath)
            {
                tView.Nodes.Clear();
                SetNode(tView, strSearchPath);
                tView.TopNode.Expand();
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
               //if you want to search .doc or docx file then:
               // var files = d.GetFiles("*.doc*");
                var files = d.GetFiles("*.*");
                FileInfo[] subfileInfo = files.ToArray<FileInfo>();
    
                if (subfileInfo.Length > 0)
                {
                    for (int j = 0; j < subfileInfo.Length; j++)
                    {
                       //Checking for Hiddend files
                        bool isHidden = ((File.GetAttributes(subfileInfo[j].FullName) & FileAttributes.Hidden) == FileAttributes.Hidden);
                        if (!isHidden)
                        {                       
                                TreeNode treeNode = new TreeNode();
                                string path = subfileInfo[j].FullName;
                                string name = subfileInfo[j].Name;
                                treeNode = node.Nodes.Add(path, name);                 
                        }
                    }
                }
            }
