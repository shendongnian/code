        //Use querystring
        protected void NameLabel_Click(object sender, EventArgs e)
        {
            var link = sender as LinkButton;
            Response.Redirect(String.Format("anotherpage.aspx?name={0}", link.Text));
        }
        //Use session
        protected void NameLabel_Click(object sender, EventArgs e)
        {
            var link = sender as LinkButton;
            Session["name"] = link.Text;
            Response.Redirect("anotherpage.aspx?");
        }
