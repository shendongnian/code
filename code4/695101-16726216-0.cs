    public string saveEachTask(string imageData, string desc, string tid)
    {
      var imglist = imageData.Split(',').ToList();
      var desclist = desc.Split(',').ToList();
      var idlist = tid.Split(',').ToList();
      int maxLength = Math.Max(imglist.Count, Math.Max(desclist.Count, idlist.Count));
      for (int i = 0; i < maxLength; ++i)
      {
        string imgItem = (i < imglist.Count ? imglist[i] : null);
        string descItem = (i < desclist.Count ? desclist[i] : null);
        string idItem = (i < idlist.Count ? idlist[i] : null);
        // TODO: Process imgItem, descItem, idItem
      }
      return "Saved Succesfully";
    }
