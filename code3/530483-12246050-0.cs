    public static void SaveJpeg(string path, Image img)
     {
      Image NewImage = img;
      img.Dispose(); <------- Here
      ...
     }
