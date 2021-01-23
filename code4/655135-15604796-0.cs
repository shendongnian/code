           TreeNode root = new TreeNode("Registered");
           TreeView1.BeginUpdate(); 
            treeView1.Nodes.Add(root);      //Hard code
            root.Expanded=true;
            ds.Relations.Add("Regsd", ds.Tables["tRegistered"].Columns["pDate"], ds.Tables["tRegistered"].Columns["pDate"]);
            foreach (DataRow dr in ds.Tables["tRegistered"].Rows)
            {
                DateTime dt = Convert.ToDateTime(dr["pDate"]);
                TreeNode tn = new TreeNode(String.Format("{0:dd-MMM-yyyy}", dt));
                tn.Expanded=true;
                foreach (DataRow drChild in dr.GetChildRows("Regsd"))
                {
                    TreeNode childTn = new TreeNode(drChild["pId"].ToString() + "- " + drChild["pName"].ToString());
                    childTn.Tag = drChild["pId"];
                    childTN.Expanded=true;
                    tn.Nodes.Add(childTn);
                }
                root.Nodes.Add(tn);
                TreeView1.EndUpdate() 
                //root.Expand();      
