    if (ds_idoc_li.Tables[0].Rows.Count == 0)
    {
       SEG_NUM_L = 1;
    }
    else
    {
      foreach(DataRow row in ds_idoc_li.Tables["AGR3PL_LINE"].Rows)
      {
       int var = Convert.ToInt32(row["SEG_NUM"]);
       SEG_NUM_L = var;
       }
       SEG_NUM_L++;  
    }
   
