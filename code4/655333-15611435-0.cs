    string[] splitSpecial(string words, int lenght)
    {
      // The new result, will be turned into string[]
      var newSplit = new List<string>();
      // Split on normal chars, ie newline, space etc
      var splitted = words.Split();
      // Start out with null
      string word = null;
   
      for (int i = 0; i < splitted.Length; i++)
      {
          // If first word, add
          if (word == null)
          {
              word = splitted[i];
          }
          // If too long, add
          else if (splitted[i].Length + 1 + word.Length > lenght)
          {
              newSplit.Add(word);
              word = splitted[i];
          }
          // Else, concatenate and go again
          else
          {
              word += " " + splitted[i];
          }
      }
      // Flush what we have left, ie the last word
      newSplit.Add(word);
      // Convert into string[] (a requirement?)
      return newSplit.ToArray();
    }
