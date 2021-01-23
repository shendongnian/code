        void FileTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode newSelected = e.Node;
            FileList.Items.Clear();
            DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
            ListViewItem.ListViewSubItem[] subItems;
            ListViewItem item = null;
            ContentImg.Images.Clear();
            int CurrentImg = 0;
            foreach (FileInfo file in nodeDirInfo.GetFiles())
            {
                string fileName = file.Name;
                foreach (PictureBox PB in ContentItems)
                {
                    if (fileName == PB.Name)
                    {
                        //Get Image
                        ContentImg.Images.Add(PB.Image);
                        item = new ListViewItem(file.Name, CurrentImg);
                        subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"), 
                     new ListViewItem.ListViewSubItem(item, 
						file.LastAccessTime.ToShortDateString())};
                        item.SubItems.AddRange(subItems);
                        FileList.Items.Add(item);
                        CurrentImg += 1;
                    }
                }
            }
