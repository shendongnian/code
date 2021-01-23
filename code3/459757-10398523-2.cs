            protected void gvSHowMostViewedArticles_RowDataBound(object sender, GridViewRowEventArgs e)
            {
                //Show Message
                LinkButton lb = e.Row.FindControl("lnkBtnShowMessage") as LinkButton;
                if (lb != null)
                    ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lb);
        
        
                //Activate
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbActivate = e.Row.FindControl("lnkBtnActivateComment") as LinkButton;
                    if (lbActivate != null)
                        ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lbActivate);
        
                    lbActivate.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to Activate this comment " +
                    DataBinder.Eval(e.Row.DataItem, "ID") + "')");
                }
                //De Activate
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    LinkButton lbActivate = e.Row.FindControl("lnkBtnDeActivateComment") as LinkButton;
                    if (lbActivate != null)
                        ScriptManager.GetCurrent(this).RegisterAsyncPostBackControl(lbActivate);
        
                    lbActivate.Attributes.Add("onclick", "javascript:return " +
                    "confirm('Are you sure you want to De-Activate this comment " +
                    DataBinder.Eval(e.Row.DataItem, "ID") + "')");
                }
            }
        
        
          protected void gvSHowMostViewedArticles_RowCommand(object sender, GridViewCommandEventArgs e)
            {
                //Show Message
                if (e.CommandName == "showMessage")
                {
                    int sno = Convert.ToInt32(e.CommandArgument);
                    string strSql = "SELECT * FROM Comments WHERE comID = " + sno;
                    DataSet ds = DataProvider.Connect_Select(strSql);
                    lblCommentMessage.Text = ds.Tables[0].Rows[0]["comMessage"].ToString();
                }
        
                // Activate Comment
                if (e.CommandName == "ActivateComment")
                {
                    int sno = Convert.ToInt32(e.CommandArgument);
                    String strSql = "UPDATE Comments SET Visible = 1 WHERE ID = " + sno;
                    DataProvider.Connect_Select(strSql);
                    lblCommentMessage.Text = "Activated";
                }
        
                // De Activate Comment
                if (e.CommandName == "DeActivateComment")
                {
                    int sno = Convert.ToInt32(e.CommandArgument);
                    String strSql = "UPDATE Comments SET Visible = 0 WHERE ID = " + sno;
                    DataProvider.Connect_Select(strSql);
                    lblCommentMessage.Text = "Deactivate";
        
                }
            }
