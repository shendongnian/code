    public static class TreeBuilder
    {
        public static void BuildTree(TreeView treeview)
        {
            // Load database records into strongly typed list
            List<TreeNodeRecord> records = GetTreeNodeRecords();
            //Pause redrawing for the tree view control
            treeview.BeginUpdate();
            // Recursively add all items in the list to the tree
            AddNodes(records, "0", treeview.Nodes);
            // Resume redrawing for the tree view control
            treeview.EndUpdate();
        }
        // A method that reads all of the database records, and returns a strongly typed list for further processing
        private static List<TreeNodeRecord> GetTreeNodeRecords()
        {
            List<TreeNodeRecord> records = new List<TreeNodeRecord>();
            string MyConString = ConfigurationManager.ConnectionStrings["College_Management_System.Properties.Settings.cmsConnectionString"].ConnectionString;
            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand command = connection.CreateCommand())
                {
                    MySqlDataReader reader;
                    command.CommandText = "select * from menu_details";
                    using (reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            TreeNodeRecord newRecord = new TreeNodeRecord
                            {
                                Key = reader[3].ToString(),
                                ParentKey = reader[2].ToString(),
                                Name = reader[1].ToString()
                            };
                            records.Add(newRecord);
                        }
                    }
                }
            }
            return records;
        }
        // A recursive method to add nodes to the tree
        private static void AddNodes(List<TreeNodeRecord> records, string parentKey, TreeNodeCollection nodes)
        {
            List<TreeNodeRecord> children = records.Where(r => r.ParentKey == parentKey).ToList();
            foreach (TreeNodeRecord child in children)
            {
                TreeNode newNode = nodes.Add(child.Key, child.Name);
                AddNodes(records, child.Key, newNode.Nodes);
            }
        }
    }
