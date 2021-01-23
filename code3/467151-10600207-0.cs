    using (StreamReader reader = new StreamReader("Content/Levels/" + mapName + ".txt"))
    {
      for (int i = 0; i < 20; i++) {
        string[] objLoc = reader.ReadLine().Split(',')
        for (int j = 0; j < 36; j++) {
          map[i, j] = Convert.ToInt32(objLoc[j]);
        }
      }
    }
