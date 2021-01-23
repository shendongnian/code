     private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
            {
                try
                {
                    TreeNode current = e.Node;
                    string path = current.FullPath;
                    string[] Files = Directory.GetFiles(path);
                    string[] Directories = Directory.GetDirectories(path);
                    string[] subinfo = new string[3];
                    listView1.Clear();
                    listView1.Columns.Add("Name", 255);
                    listView1.Columns.Add("Size", 100);
                    listView1.Columns.Add("Type", 80);
                    foreach (string Dname in Directories)
                    {
                        subinfo[0] = GetFileName(Dname);
                        subinfo[1] = "";
                        subinfo[2] = "FOLDER";
                        ListViewItem DItems = new ListViewItem(subinfo);
                        listView1.Items.Add(DItems);
                    }
                    foreach (string Fname in Files)
                    {
                        subinfo[0] = GetFileName(Fname);
                        subinfo[1] = GetSizeinfo(Fname);
                        subinfo[2] = GetTypeinfo(Fname);
                        ListViewItem FItems = new ListViewItem(subinfo);
                        FItems.Tag = Fname; // set the tag here
                        listView1.Items.Add(FItems);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!!");
                }
    
            }
