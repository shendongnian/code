    [Authorize]
    public FilePathResult GetImage()
    {
        string user = User.Identity.Name;
        var path = Server.MapPath(
            string.Format("~/files/uploads/users/{0}/avatar/", user)
        );
        var ext = this.GetImageExtension(path, user);
        if (string.IsNullOrEmpty(ext))
        {
            return File(
                Server.MapPath("~/files/commonFiles/users/avatar/noavatar.png"), 
                "image/png", 
                "noavatar.png"
            );
        }
        var file = Path.ChangeExtension(Path.Combine(path, user), ext);
        return File(file, "image/" + ext, user + "." + ext);
    }
