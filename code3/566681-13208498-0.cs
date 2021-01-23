    for (int intCount = 0; intCount < ds.Tables[0].Rows.Count; intCount++)
    {
         var val=ds.Tables[0].Rows[intCount][value].ToString();
         //check if it already exists
         if(!cmb.Items.Contains(val))
         {
                cmb.Items.Add(val);
         }
    }
