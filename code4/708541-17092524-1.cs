        string ScrubString(string dirty)
        {
            char[] charArray = dirty.ToCharArray();
            StringBuilder strBldr = new StringBuilder(dirty.Length);
            for (int i = 0; i < charArray.Length; i++)
            {
               if(IsXmlSafe(charArray[i]))
               {
                  strBldr.Append(charArray[i]);
               }
               else
               {
                  //do something to escape or replace that character. 
               }
            }
            retrun strBldr.ToString();
        }
        bool IsXmlSafe(char c)
        {
           int charInt = Convert.ToInt32(c);
           
           return charInt == 9
               || charInt == 13
               || (charInt >= 32    && charInt <= 9728)
               || (charInt >= 9983  && charInt <= 55295)
               || (charInt >= 57344 && charInt <= 65533)
               || (charInt >= 65536 && charInt <= 1114111);
        }
