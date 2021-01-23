    foreach (DataRow dr in dt.Select("ParentMenuId=" + 0))
    {
       if(dr["MenuName"]!=null && dr["MenuId"]!=null && dr["MenuDescription"]!=null)
       {
         menuBar.Items.Add(new MenuItem(dr["MenuName"].ToString(),
                dr["MenuId"].ToString(), "",
                dr["MenuDescription"].ToString()));
       }
    }
    foreach (DataRow dr in dt.Select("ParentMenuId >" + 0))
    {
       if(dr["MenuName"]!=null && dr["MenuId"]!=null && dr["MenuDescription"]!=null)
       {
         MenuItem mnu = new MenuItem(dr["MenuName"].ToString(),
                       dr["MenuId"].ToString(),
                       "", dr["MenuDescription"].ToString());
       }
       if(dr["ParentMenuId"]!=null)
       {
         menuBar.FindItem(dr["ParentMenuId"].ToString()).ChildItems.Add(mnu);
       }
    }
