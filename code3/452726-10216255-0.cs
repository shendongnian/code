    public ActionResult LoadImage(string name)
    {
        
        string imageBasePath = "[GET FROM CONFIG]";
    string fullPath = imageBasePath + name;
    
        return base.File(fullPath, "image/jpg");
    }
