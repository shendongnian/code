        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Write("I was programatically called!");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            string pbref = Page.GetPostBackEventReference(LinkButton1);
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "KeyName", "<script>" + pbref + "</script>");
        }
