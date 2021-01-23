    foreach (string path in deleteItems)
    {
      if(File.Exists(path)){
        File.Delete(path);
      }elseif(Directory.Exists(path)){
        Directory.Delete(path);
      }
    }
