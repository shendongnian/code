    public ActionResult GetUserProfileImage() 
    {
        if (Member.LogIn()) 
        {
            DBFile file = GetMemberPicFromDB();
            return File(file.Content, file.ContentType);
        }
        else 
        {
            string image = Server.MapPath("~/content/img/sample_user.png");
            return File(image, "image/png");
        }
    }
