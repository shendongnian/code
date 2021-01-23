        protected void Page_Load(object sender, EventArgs e)
        {
            string serverPath = Server.MapPath("~/Test/") + Path.GetFileName("~/Test/TestImg.jpg");
            string imgUrl = "~/Test/TestImg.jpg";
            if (File.Exists(serverPath))
            {
                TestPicture.ImageUrl = imgUrl;
            }
            else
            {
                TestPicture.ImageUrl = "";
                //TestPicture.Visible = false;
                //TestPicture.ImageUrl = "Picture Not Available.jpg";
                //or do other error checking here
            }
        }
