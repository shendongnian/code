       for (int i = 0; i < dt.Rows.Count; i++)
       {
            row = dt.Rows[i];
            var ds = db.getComboxedCombinedRSS( row[0].ToString()); 
            //The string above assigns all the time and the last one will win.
       }
       GridView1.DataSourse = ds;
       GridView1.DataBind();
       //When grid binds 
