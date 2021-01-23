    foreach (string word in words)
    {
      var blacklist = 0;
      if (FindMyText(word))
      {
        blacklist = 1;
        MessageBox.Show("Current word: " + word + " is blacklisted!");
        continue;
      } else {
         //...
      }
     }
