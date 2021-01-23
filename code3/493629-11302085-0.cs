    for (int i = 0; i < 10 ; i++)
    {
        LinkButton link = new LinkButton() { ID = "link_" + i };
        link.Text = "Link " + i;
        link.Click+=new EventHandler(link_Click);
        this.Form.Controls.Add(link);
    }
    protected void link_Click(object sender, EventArgs e)
    {
        //Every time a link is clicked it will get here in the server side
    }
