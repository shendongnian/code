        public static List<string> GenerateMonthNames(string prefixText)
        {
          List<string> items = new List<string>();
             items.Add("Oliver");
             items.Add("Olsen");
             items.Add("learns");
             items.Add("how");
             items.Add("change");
             items.Add("world");
             items.Add("engaging");  
          List<string> retLst= new List<string>();
          string[] strArray = items.ToArray();
          string retstr = string.Empty;
          int strNumber;
          int strIndex = 0;
          for (strNumber = 0; strNumber < strArray.Length; strNumber++)
          {
              strIndex = strArray[strNumber].IndexOf(prefixText);
              if (strIndex >= 0)
              {
                  retstr = strArray[strNumber];
                  retLst.Add(retstr);
              }
          }
          items.Clear();
          return retLst;
         }
