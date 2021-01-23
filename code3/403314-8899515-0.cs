    protected void rptComments_ItemCommand(object source, RepeaterCommandEventArgs e) {
        if(e.CommandName.ToLower().Equals("deletecomment")) {
            clsComment comment = new clsComment("mediadb");
            comment.CommentID = int.Parse(((LinkButton)e.CommandSource).CommandArgument);
            comment.DeleteRecord();
            rptComments.DataBind();
        }
    }
