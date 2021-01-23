        public static String FilterString(string value)
        {
          string[] lsWords = value.Split(' ');
          StringBuilder lsbBuilder = new StringBuilder();
        
          bool lbIncluding = true;
        
          foreach(String lsWord in lsWords)
          {
            if (lsWord.StartsWith("[") && lsWord.EndsWith("]"))
               lbIncluding = (lsWord != "[ERROR]");
        
            if (lbIncluding)
            {
              if (lsbBuilder.Length > 0) lsbBuilder.Append(' ');
              lsbBuilder.Append(lsWord);
            }
          }
        
          return lsbBuilder.ToString();
        }
    
    ....
        
        string a = "[ERROR] = any thing And [ID] > 20 And [NAME] like Varun";
        string b = "[AGE] < 60 Or [ERROR] like Exception And [ID] > 20 And [NAME] like Varun And [ERROR] = any thing ";
        string c = "[ID] > 20 And`enter code here` [NAME] like Varun And [ERROR] = any thing";
        
        a = FilterString(a);
        b = FilterString(b);
        c = FilterString(c);
