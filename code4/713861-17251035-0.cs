        public Form1()
        {
            InitializeComponent();
            this.treeView1.NodeMouseClick += new TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            PopulateTreeView();
        }
     private void PopulateTreeView()
       {
           TreeNode rootNode;
 
           DirectoryInfo info = new DirectoryInfo(@"c:\\");
           if (info.Exists)
           {
               rootNode = new TreeNode(info.Name);
               rootNode.Tag = info;
               GetDirectories(info.GetDirectories(), rootNode);
               treeView1.Nodes.Add(rootNode);
           }
       }
       private void GetDirectories(DirectoryInfo[] subDirs, TreeNode nodeToAddTo)
       {
           TreeNode aNode;
           //DirectoryInfo[] subSubDirs;
           foreach (DirectoryInfo subDir in subDirs)
           {
               aNode = new TreeNode(subDir.Name, 0, 0);
               aNode.Tag = subDir;
               aNode.ImageKey = "folder";
               /*  try
                 {
                       subSubDirs = subDir.GetDirectories();
                       if (subSubDirs.Length != 0)
                       {
                           GetDirectories2(subSubDirs, aNode);
                       }
                 }
                 catch (System.UnauthorizedAccessException)
                 {
                     subSubDirs = new DirectoryInfo[0];
                 }*/
               nodeToAddTo.Nodes.Add(aNode);
           }
       }
       void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
       {               
           try
           {
               DirectoryInfo d = new DirectoryInfo(@e.Node.FullPath);
               if (e.Node.Nodes.Count > 0) { /*Do Nothing.*/ } else { GetDirectories(d.GetDirectories(), e.Node); e.Node.Expand(); }
               TreeNode newSelected = e.Node;
               listView1.Items.Clear();
               DirectoryInfo nodeDirInfo = (DirectoryInfo)newSelected.Tag;
               ListViewItem.ListViewSubItem[] subItems;
               ListViewItem item = null;
               foreach (DirectoryInfo dir in nodeDirInfo.GetDirectories())
               {
                   item = new ListViewItem(dir.Name, 0);
                   subItems = new ListViewItem.ListViewSubItem[]
                    {new ListViewItem.ListViewSubItem(item, "Directory"), 
                     new ListViewItem.ListViewSubItem(item, 
						dir.LastAccessTime.ToShortDateString())};
                   item.SubItems.AddRange(subItems);
                   listView1.Items.Add(item);
               }
               foreach (FileInfo file in nodeDirInfo.GetFiles())
               {
                   item = new ListViewItem(file.Name, 1);
                   subItems = new ListViewItem.ListViewSubItem[]
                    { new ListViewItem.ListViewSubItem(item, "File"), 
                     new ListViewItem.ListViewSubItem(item, 
						file.LastAccessTime.ToShortDateString())};
                   item.SubItems.AddRange(subItems);
                   listView1.Items.Add(item);
               }
               listView1.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
           }
           catch (Exception ex)
           {
                if (ex is System.NullReferenceException || ex is System.UnauthorizedAccessException)
                {
                    // Do Nothing.
                }
           }
          
           
       }`
