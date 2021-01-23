            GridViewRow gvrow = (GridViewRow)btn.NamingContainer;
            if (gvrow != null)
            {
                //Get the Row Index
                int rowIndex = gvrow.RowIndex;
                //Get the DataKey value
                Session["formID"] = gvHistory.DataKeys[rowIndex].Value.ToString();
                Label1.Text = Session["formID"].ToString();
            }
