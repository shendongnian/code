    foreach (ListItem item in cbxlFeatures.Items)
    {
      foreach (DataRow row in dt.Rows)
        {
           if (item.Value.Equals(row["Id"].ToString()))
            {
              item.Selected = Convert.ToBoolean(row["Id"]); 
             continue;
    
            }
             break;
         }
     }
