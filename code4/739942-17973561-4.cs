    for (int i = 0; i < myListOfStrings.Count; i++)
    {
         char[] chars = myListOfStrings[i].ToCharArray();
         for (int j = 0; j < chars.Count(); j++)
         {
             if (!Char.IsDigit(chars[j]))
             {
                 if (j + 1 < chars.Count())
                 {
                     chars[j] = 'f'; //'f' being your replacing character
                     myListOfStrings[i] = new string(chars);
                 }
                 break;
             }
         }
    }
