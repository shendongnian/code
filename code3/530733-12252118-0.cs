    private void processJsonInput()
    {
      var reader = new StreamReader(new FileStream("d:\\jsonfile.txt", FileMode.Open));
      JsonSerializer serializer = new JsonSerializer();
      var o = (JToken)serializer.Deserialize(new JsonTextReader(reader));
      foreach (var child in o["roots"]["bookmark_bar"]["children"])
      {
        processChild(child);
      }
    }
    private void processChild(JToken child)
    {
      if (child["type"].ToString() == "url")
      {
        Console.WriteLine("URL");
      } 
      else if (child["type"].ToString() == "folder")
      {
        Console.WriteLine("FOLDER");
        // process sub childrens in the folder
        foreach (var subChild in child["children"])
        {
          processChild(subChild);
        }
      }
    }
