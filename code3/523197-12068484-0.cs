    var imageList = new List<Image>();
    foreach (var control in this.Controls)
    {
       if (control is Image)
       {
         imageList.Add((Image)control);
       }
    }
    foreach (Image img in imageList)
      //Can store all available image url
