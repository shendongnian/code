           if (e.Row.RowType == DataControlRowType.DataRow)
            {
              Label LabelStatus = (Label)e.Row.FindControl("lblStatus");
                if(LabelStatus.Text.Trim().ToLower().Equals("inactive"))
                {
                    e.Row.BackColor = System.Drawing.Color.Gray;
                }                   
               
            }
