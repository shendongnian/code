    protected void Page_Init(object sender, EventArgs e)
    {
        createTagButtons();
    }
    private void createTagButtons()
    { 
        var tblTags = new DataTable();
        using (var con = new SqlConnection(connectionString))
        using (var da = new SqlDataAdapter("SELECT TagID, TagName FROM dbo.Tags ORDER BY TagName", con))
        {
            da.Fill(tblTags);
        }
        foreach (DataRow row in tblTags.Rows)
        {
            int tagID =  row.Field<int>("TagID");
            string tagName = row.Field<string>("TagName");
            LinkButton tagButton = new LinkButton();
            tagButton.ID = "tagButton_" + tagID;
            tagButton.CommandArgument = tagName;
            tagButton.Click += TagLinkClicked;
            this.TagPanel.Controls.Add(tagButton);
        }
    }
    private void TagLinkClicked(Object sender, EventArgs e)
    {
        LinkButton tagLink = (LinkButton)sender;
        string url = string.Format("Tags.aspx?name={0}", tagLink.CommandArgument);
        Response.Redirect(url);
    }
