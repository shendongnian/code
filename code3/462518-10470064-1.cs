    protected void RPT_Bordereaux_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
       {
       }
    }
            
        
    protected static string GetValue(object dataItem)
    {
       string year = Convert.ToString(DataBinder.Eval(dataItem, "year"));
        if (!string.IsNullOrEmpty(year))
         {
           return Convert.ToString(year);
         }
         else
                {
                    return "blahbla";
                }
            
             }
