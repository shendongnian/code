        public Form1()
        {
            InitializeComponent();
            #if DEMO
               var changeNodes = treeView1.Nodes.Find("Profiles", true);
               if (changeNodes.Length>0)
               {
                   foreach(TreeNode node in changeNodes)
                   {
                        node.Name = "Lines";
                        node.Text = "Lines text";
                        // add/set whatever else you need in demo mode
                   }
               }
               // or remove all nodes and add new ones
            #endif 
        }
