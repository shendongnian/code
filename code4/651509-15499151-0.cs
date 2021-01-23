      List<string> strs = new List<string>() { "ABC123",
                                               "ABC245",
                                               "ABC435",
                                               "NOTABC",
                                               "ABC Oh say can You see" 
                                              };
      for (int i = 0; i < strs.Count; i++)
      {
        //Set the current string variable
        string str = strs[i];
        //Get the index of "ABC"
        int index = str.IndexOf("ABC");
        //Do you want to remove if ABC doesn't exist?
        if (index == -1)
          continue;
        //Set the index to be the next character from ABC
        index += 3;
        //If the index is within the length with 3 extra characters (123)
        if (index <= str.Length && (index + 3) <= str.Length)
          if (str.Substring(index, 3) == "123")
            strs.RemoveAt(i);
      }
