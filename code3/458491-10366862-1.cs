       public void Folder(_Folder folder)
        {
            ListViewItem item = new ListViewItem();
            item.Text = folder.Name;
            item.ToolTipText = folder.Path;
            item.Tag = item.ImageIndex;
            item.Name = item.Text;
            item.Group = Program.MainForm.listView1.Groups[1];
            item.ImageIndex = Program.MainForm._iconListManager.AddFolderIcon(folder.Path);
            Program.MainForm.listView1.Items.Add(item);
        }
        public void File(_File file)
        {
            ListViewItem item = new ListViewItem();
            item.Text = file.Name;
            item.ToolTipText = file.Path;
            item.Tag = item.ImageIndex;
            item.Name = item.Text;
            item.SubItems.Add(Program.MainForm.CnvrtUnit(file.Size));
            item.Group = Program.MainForm.listView1.Groups[0];
            item.ImageIndex = Program.MainForm._iconListManager.AddFileIcon(file.Path);
            Program.MainForm.listView1.Items.Add(item);
        }
