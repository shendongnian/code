    StringBuilder sb = new StringBuilder();
    foreach(string file in allFiles)
    {
      if (file.Contains("Passed"))
      {
         sb.Append(file);
      }
    }
  
    resultsText.Text = sb.ToString();
