    protected void Page_Init(object sender, EventArgs e)
    {
        ImageButton imgBtn = new ImageButton();
        imgBtn.ID = "img_id";
        imgBtn.ImageUrl = "~/images/Workflow/digital-signature-pic.jpg";
        imgBtn.AlternateText= "Signature";
        imgBtn.Click += (source, args) =>
        {
            // do something
        };
        Panel1.Controls.Add(imgBtn);
    }
