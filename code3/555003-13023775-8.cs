    private void GenerateMenus()
    {
        clsMenu obj = new clsMenu();
        System.Data.DataSet ds = new System.Data.DataSet();
        String PageName = "";
        PageName = Path.GetFileName(Page.AppRelativeVirtualPath);
        ds = obj.GetMenusByRole(GetRoleId(), PageName);
        StringBuilder sb = new StringBuilder("<ul class='tabs'>");
        foreach (System.Data.DataRow row in ds.Tables[0].Rows)
        {
            sb.Append(String.Format("<li class='{0}'><a rel='{1}' href='{1}' > {2} </a> ", Convert.ToString(row["css"]), ResolveUrl(Convert.ToString(row["PagePath"])), Convert.ToString(row["MenuName"])));
            //sb.Append(String.Format("<li '><a rel='{0}' href='{0}' > {1} </a> ", ResolveUrl(Convert.ToString(row["PagePath"])), Convert.ToString(row["MenuName"])));
            System.Data.DataTable t = CCMMUtility.GetFilterDataforIntColumn("MenuID", Convert.ToString(row["MenuID"]), ds.Tables[1]);
            if (t.Rows.Count > 0)
            {
                sb.Append("<ul>");
                for (int i = 0; i < t.Rows.Count; i++)
                {
                    sb.Append(String.Format("<li><a href='{0}' class='dir' style='cursor: pointer;'>{1}</a></li>", ResolveUrl(Convert.ToString(t.Rows[i]["PagePath"])), Convert.ToString(t.Rows[i]["PageAliasName"])));
                }
                sb.Append("</ul>");
            }
            sb.Append("</li>");
        }
        sb.Append("</ul>");
        ltMenus.Text = sb.ToString();
    }
