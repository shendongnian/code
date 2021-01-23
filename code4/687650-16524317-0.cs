    string image = Image1.ImageUrl.ToString();
    Session["logo"] = image;
    protected void Page_Load(object sender, EventArgs e)
    {
        string imgURL = Session["logo"];
        ImageButton1.Controls.Add(new Image() { ImageURL = imgURL });
    }
