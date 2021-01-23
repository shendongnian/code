    for (int i = 0; i < GridView1.Rows.Count; i++)
       {
    
            CheckBox chck = (CheckBox)GridView1.Rows[i].FindControl("chck");
    
           if (chck  != null)
           {
             if (chck.Checked)
             {
                GridView1.Rows.RemoveAt[i];
             }
           }
      }
