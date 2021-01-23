    private void btnRemoveComment_Click(object sender, EventArgs e)
    {
      CommentFactory.RemoveComment(CurrentPage);
      Response.Redirect("news.aspx");
    }
