     protected void Page_Load(object sender, EventArgs e)
        {
            conStr = ConfigurationManager.ConnectionStrings["conString"].ConnectionString;
            conn = new OleDbConnection(conStr);
            BindTreeViewControl();
        }
        private void BindTreeViewControl()
        {
            try
            {
                DataSet ds = GetDataSet("Select ProductId,ProductName,ParentId from ProductTable");
                DataRow[] Rows = ds.Tables[0].Select("ParentId = 0"); 
                for (int i = 0; i < Rows.Length; i++)
                {
                    TreeNode root = new TreeNode(Rows[i]["ProductName"].ToString(), Rows[i]["ProductId"].ToString());
                    root.SelectAction = TreeNodeSelectAction.Expand;
                    CreateNode(root, ds.Tables[0]);
                    treeviwExample.Nodes.Add(root);
                }
            }
            catch (Exception Ex) { throw Ex; }
        }
        public void CreateNode(TreeNode node, DataTable Dt)
        {
            DataRow[] Rows = Dt.Select("ParentId =" + node.Value);
            if (Rows.Length == 0) { return; }
            for (int i = 0; i < Rows.Length; i++)
            {
                TreeNode Childnode = new TreeNode(Rows[i]["ProductName"].ToString(), Rows[i]["ProductId"].ToString());
                Childnode.SelectAction = TreeNodeSelectAction.Expand;
                node.ChildNodes.Add(Childnode);
                CreateNode(Childnode, Dt);
            }
        }
        private DataSet GetDataSet(string Query)
        {
            DataSet Ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(Query, conn);
                da.Fill(Ds);
            }
            catch (Exception dex) { }
            return Ds;
        }
