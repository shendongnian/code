    string uploaddir;
    string randomName;
    string decodedData;
    // ....
    System.IO.File.WriteAllText(
      System.IO.Path.Combine(uploaddir, randomName),
      decodedData
    );
