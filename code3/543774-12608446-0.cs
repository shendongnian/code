     if(e.Row.RowType == DataControlRowType.DataRow)
     {
          //To check condition on date time 
         if (Convert.ToDateTime(DataBinder.Eval(e.Row.DataItem, "endTimeStamp")) == Convert.ToDateTime("0001-01-01 00:00:00.0000000"))
         {
            e.Row.BackColor = System.Drawing.Color.Red;
         }
      }
