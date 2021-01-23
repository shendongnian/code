    protected void btnWall_Click(object sender, EventArgs e)
    {
        con.SendWallPost(con.GetId(Membership.GetUser().UserName), Convert.ToInt32(Request.QueryString["ID"]), txtWall.Text); //This method is sending the post
        //upWall.Update();
        gvWallPosts.DataBind();
    }
