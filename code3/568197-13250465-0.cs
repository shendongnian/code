    public static bool IsTagsOnly(string html)
    {
      bool inTag = false;
      char attChar = '\0';
      foreach(char c in html)
      {
        if(char.IsWhiteSpace(c))//include or excise this bit depending on whether you count whitespace as "content"
        {
          continue;
        }
        if(!inTag)
        {
          if(c == '<')
            inTag = true;
          else
            return false;
        }
        switch(c)
        {
          case '\'':
            switch(attChar)
            {
              case '\'':
                attChar = '\0';
                break;
              case '\0':
                attChar = '\'';
                break;
            }
            break;
          case '"':
            switch(attChar)
            {
              case '"':
                attChar = '\0';
                break;
              case '\0':
                attChar = '"';
                break;
            }
            break;
          case '>':
            if(attChar == '\0')
              inTag = false;
            break;
        }
      }
      return true;
    }
