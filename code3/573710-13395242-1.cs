    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ListItem listItem = new ListItem("Picture 1", "../adGallery/images/pictures/1.jpg");
            listItem.Attributes.Add("class", "image0");
            ImagesBulletedList.Items.Add(listItem);
            listItem = new ListItem("Picture 2", "../adGallery/images/pictures/2.jpg");
            listItem.Attributes.Add("class", "image1");
            listItem.Attributes.Add("title", "A title for 10.jpg");
            ImagesBulletedList.Items.Add(listItem);
            // ...
        }
    }
