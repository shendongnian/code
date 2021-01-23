        protected void RowDataBound(Object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
                //check role
                 if (condition)
                   e.Row.BackColor = Color.Red;
                 else
                   e.Row.BackColor = Color.Green;  
                //or set you individual control background 
                 //get any control
                  var chk = (CheckBox)e.Row.FindControl("chkb");
                 //set background
                  chk.BackColor = Color.Red;//etc
             }
        }
