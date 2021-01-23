    string s = "heloooooooooooooooooooooo worrrllllllllllllld!";
    char[] chr = s.ToCharArray();
    StringBuilder sb = new StringBuilder();
    char currentchar = new char();
    int charCount = 0;
    
    foreach (char c in chr)
    {
         if (c == currentchar)
         {
             charCount++;
         }
         else
         {
             charCount = 0;
         }
         if ( charCount < 6)
         {
             sb.Append(c);
         }
         currentchar = c;
     }
     Console.WriteLine(sb.ToString());
     //Output heloooooo worrrlllllld!
