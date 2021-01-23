    public string GetImage(string name)
    {
      string path = Server.MapPath(("~/Admin/Images/" + name).ToString()); 
      return path;
    }
