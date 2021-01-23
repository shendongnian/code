    public string GetImage(string name)
    {
      string path = Path.Combine(Server.MapPath(("~/Admin/Images/" , name)); 
      return path;
    }
