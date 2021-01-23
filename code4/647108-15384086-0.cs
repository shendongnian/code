    string line = reader.ReadLine();
    while(line != null)
    {
      string[] words = 
        line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
      foreach(var word in words)
      {
        word = word.Trim(); //get rid of any whitespace
        if(string.Length != 0)
          datalinestream.Add(word);
      }
      LuceneDB.AddUpdateLuceneIndex(new MATS_Doc( datalinestream));
      datalinestream.Clear();
    }
