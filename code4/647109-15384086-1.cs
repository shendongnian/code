    string line = reader.ReadLine();
    string wordTemp;
    while(line != null)
    {
      string[] words = 
        line.Split(";".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
      foreach(var word in words)
      {
        wordTemp = word.Trim(); //get rid of any whitespace
        if(wordTemp.Length != 0)
          datalinestream.Add(wordTemp);
      }
      LuceneDB.AddUpdateLuceneIndex(new MATS_Doc( datalinestream));
      datalinestream.Clear();
      line = reader.ReadLine();
    }
