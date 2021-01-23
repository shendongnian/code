            TreeNode root = new TreeNode("Registered");
            root.Expand();
            ds.Relations.Add("Regsd", ds.Tables["tRegistered"].Columns["pDate"], ds.Tables["tRegistered"].Columns["pDate"]);
            foreach (DataRow dr in ds.Tables["tRegistered"].Rows)
            {
                DateTime dt = Convert.ToDateTime(dr["pDate"]);
                TreeNode tn = new TreeNode(String.Format("{0:dd-MMM-yyyy}", dt));
                tn.Expand();
                foreach (DataRow drChild in dr.GetChildRows("Regsd"))
                {
                    TreeNode childTn = new TreeNode(drChild["pId"].ToString() + "- " + drChild["pName"].ToString());
                    childTn.Tag = drChild["pId"];
                    childTN.Expand();
                    tn.Nodes.Add(childTn);
                }
                root.Nodes.Add(tn);
                //root.Expand();      
            }
            TreeView1.BeginUpdate();
            TreeView1.Nodes.Add(root);      //Hard code
            TreeView1.EndUpdate();
