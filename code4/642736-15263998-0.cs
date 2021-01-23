        protected void rpt_ItemDataBound(object source, RepeaterCommandEventArgs e)
        {
          if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType==  ListItemType.AlternatingItem)
           {
              LinkButton btn = (LinkButton)e.Item.FindControl("btnDelete");
              btn.Attributes.Add("onclick", "if ( ! confirm( 'Delete this record?' )) return false; ");
     
        } 
