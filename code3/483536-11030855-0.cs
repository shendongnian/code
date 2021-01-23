    if (FindMyText(word))
    {
      blacklist = 1;
      MessageBox.Show("Current word: " + word + " is blacklisted!");
      continue;
    }
    else
    {
       MessageBox.Show("Word: " + word);
      AddWordToFile(word); // not black listed;
    }
