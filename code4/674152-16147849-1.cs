     protected void gvSearchResult_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                try
                {
                    if ((e.Row.RowType == DataControlRowType.DataRow))
                    {
                        LinkButton lnkbtnDetail = (LinkButton)e.Row.FindControl("lnkbtnDetail");
                        ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkbtnDetail);
                    }
                }
                catch (Exception ex)
                {
                    
                }
            }
