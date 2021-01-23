    protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
     if (e.Row.RowState == DataControlRowState.Edit )
     {
    
    
        int key = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Value);
        Label CompanyID = (Label)GridView1.Rows[e.RowIndex].FindControl("txtCompanyID");
        TextBox thisIssueDate = (TextBox)(GridView1.Rows[e.RowIndex].FindControl("txtIssueDate"));
        TextBox NoticeIntentResponseDue = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtNoticeIntentResponseDue");
        Response.Write(NoticeIntentResponseDue.Text + " " + thisIssueDate.Text);
        Response.End();
        TextBox DeadlineForQuestions = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtDeadlineForQuestions");
        TextBox BidsDue = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtBidsDue");
        TextBox ShortlistNotice = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtShortlistNotice");
        TextBox FinalSelection = (TextBox)GridView1.Rows[e.RowIndex].FindControl("txtFinalSelection");
        }  
      }
