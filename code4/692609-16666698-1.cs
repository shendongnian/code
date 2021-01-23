    protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }
        public void Bind()
        {
            DataTable dt = Get_Category();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = dt.Rows[i]["idCategory"].ToString();
                node.Value = dt.Rows[i]["nameCategory"].ToString();
                AddSubCategory(node);
                this.TreeView1.Nodes.Add(node);
            }
        }
        public void AddSubCategory(TreeNode node)
        {
            DataRow[] datarows = Get_SubCategory()
                                 .Select("idCategory='" + node.Value + "'");
            foreach (DataRow dr in datarows)
            {
                TreeNode childnode = new TreeNode();
                childnode.Text = dr["nameSubCategory"].ToString();
                childnode.Value = dr["idSubCategory"].ToString();
                AddArticles(childnode);
                node.ChildNodes.Add(childnode);
            }
        }
        public void AddArticles(TreeNode node)
        {
            DataRow[] datarows = Get_Articles()
                                .Select("idSubCategory='" + no.Value + "'");
            foreach (DataRow dr in datarows)
            {
                TreeNode childnode = new TreeNode();
                childnode.Text = dr["Subject"].ToString();
                childnode.Value = dr["SubjectID"].ToString();
                node.ChildNodes.Add(childnode);
            }
        }
        public DataTable Get_Category()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            string IDs = "1,2,3,4";
            string categories = "Category1,Category2,Category3,Category4";
            string[] list1 = IDs.Split(',');
            string[] list2 = categories.Split(',');
            dt.Columns.Add(new DataColumn("nameCategory"));
            dt.Columns.Add(new DataColumn("idCategory"));
            for (int i = 0; i < list1.Length; i++)
            {
                dr = dt.NewRow();
                dr["idCategory"] = list1[i];
                dr["nameCategory"] = list2[i];
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public DataTable Get_SubCategory()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            string IDs = "1,2,3,4,5,6,7,8,9";
            string subCategories = "SubCategory1, SubCategory2, SubCategory3, 
                                    SubCategory4, SubCategory5, SubCategory6, 
                                    SubCategory7, SubCategory8, SubCategory9";
            string idCategory = "1,2,3,4,1,2,3,4,1";
            string[] list1 = IDs.Split(',');
            string[] list2 = subCategories.Split(',');
            string[] list3 = idCategory.Split(',');
            dt.Columns.Add(new DataColumn("nameSubCategory"));
            dt.Columns.Add(new DataColumn("idSubCategory"));
            dt.Columns.Add(new DataColumn("idCategory"));
            for (int i = 0; i < list1.Length; i++)
            {
                dr = dt.NewRow();
                dr["idSubCategory"] = list1[i];
                dr["nameSubCategory"] = list2[i];
                dr["idCategory"] = list3[i];
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public DataTable Get_Articles()
        {
            DataTable dt = new DataTable();
            DataRow dr;
            string IDs = "1,2,3,4,5,6,7,8,9,10,11,12,13";
            string articles = "Articles1, Articles2, Articles3,Articles4, 
                               Articles5, Articles6, Articles7, Articles8, 
                               Articles9, Articles10, Articles11, Articles12, 
                               Articles13";
            string idSubCategory = "8,2,9,2,7,2,3,4,1,5,6,7,1";
            string[] list1 = IDs.Split(',');
            string[] list2 = articles.Split(',');
            string[] list3 = idSubCategory.Split(',');
            dt.Columns.Add(new DataColumn("nameArticle"));
            dt.Columns.Add(new DataColumn("idArticle"));
            dt.Columns.Add(new DataColumn("idSubCategory"));
            for (int i = 0; i < list1.Length; i++)
            {
                dr = dt.NewRow();
                dr["idArticle"] = list1[i];
                dr["nameArticle"] = list2[i];
                dr["idSubCategory"] = list3[i];
                dt.Rows.Add(dr);
            }
            return dt;
        }
