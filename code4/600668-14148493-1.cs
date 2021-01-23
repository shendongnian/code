        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = DataProvider.Connect_Select("SELECT * FROM Menu");
            DataTable table = ds.Tables[0];
            DataRow[] parentMenus = table.Select("ParentId = 0");
            var sb = new StringBuilder();
            string unorderedList = GenerateUL(parentMenus, table,sb);
            Response.Write(unorderedList);
        }
        private string GenerateUL(DataRow[] menu,DataTable table,StringBuilder sb)
        {
            sb.AppendLine("<ul>");
            if (menu.Length > 0)
            {
                foreach (DataRow dr in menu)
                {
                    string handler = dr["Handler"].ToString();
                    string menuText = dr["MENU"].ToString();
                    string line = String.Format(@"<li><a href=""{0}"">{1}</a>",handler,menuText);
                    sb.Append(line);
                    string pid = dr["PID"].ToString();
                    DataRow[]subMenu = table.Select(String.Format("ParentId = {0}", pid));
                    if (subMenu.Length > 0)
                    {
                        var subMenuBuilder = new StringBuilder();
                        sb.Append(GenerateUL(subMenu, table, subMenuBuilder));
                    }
                    sb.Append("</li>");
                }
            }
            sb.Append("</ul>");
            return sb.ToString();
        }
