            DataTable myDatatable;
            GridViewRow row = grdRepayment.Rows[e.RowIndex]; 
            grdRepayment.EditIndex = -1; 
            
            if (row != null)
            {
                myDatatable = (DataTable)Session["TempTable"];
                for (int i = 0; i < myDatatable.Rows.Count; i++)
                {
                    if (e.RowIndex == i)
                    {
                        myDatatable.Rows[i][1] = Convert.ToString(Client);
                        myDatatable.Rows[i][2] = Convert.ToString(Principal);
                        
                        Session["TempTable"] = myDatatable;
                        grdRepayment.EditIndex = -1;
                        grdRepayment.DataSource = myDatatable;
                        grdRepayment.DataBind();
                    }
                }
            }
          }
