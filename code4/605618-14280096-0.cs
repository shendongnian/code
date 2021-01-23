using System;
using System.Text.RegularExpressions;
public class Example
{
   public static void Main()
   {
      string pattern = ""\\b[\\w\\p{M}\\u200B\\u200C\\u00AC\\u001F\\u200D\\u200E\\u200F]+\\b"";
      string[] names = { "Mr. Henry Hunt", "Ms. Sara Samuels", 
                         "Abraham Adams", "Ms. Nicole Norris" };
      foreach (string name in names)
         Console.WriteLine(Regex.Replace(name, pattern, String.Empty));
   }
}
