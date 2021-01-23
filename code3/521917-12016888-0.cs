    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButton img1 = new ImageButton();
        img1.CssClass = "stylImage";
        img1.ImageUrl = @"~/images/Workflow/esign.jpg";
        img1.AlternateText = "Signature";
        img1.CommandName = "edit";
        img1.Click += new ImageClickEventHandler(Image_OnClientClick);
        img1.Command += new CommandEventHandler(Image_OnCommand);
        form1.Controls.Add(img1);
    }
    protected void Image_OnClientClick(object sender, ImageClickEventArgs e)
    {
        //some code...
    }
    protected void Image_OnCommand(object sender, CommandEventArgs e)
    {
        //some code...
    }
