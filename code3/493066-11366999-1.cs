    public ActionResult SomeGetACtion()
    {
      var master=new Master();
     
      foreach(itm in someCollection)
      {
        var child=new Child();
    
        byte[] imageData = GetImageByte(); //get your byte data;
        string imageBase64 = Convert.ToBase64String(imageData);
        child.ImageURL = string.Format("data:image/gif;base64,{0}", imageBase64);
        master.Children.Add(byte);
      }
    }
