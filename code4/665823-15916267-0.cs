    for (int i = 0; i < wordlist.Length; i++)
    {
      wordlist[i] = wordlist[i].Trim().TrimEnd('.').TrimEnd('!').TrimEnd('?');
      bool test = Regex.Match(wordlist[i], @"^[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(/\S*)?$").Success;  
      if (test == true)
      {
        lstWebsites.Items.Add("http://" + wordlist[i]);
      }
    } 
