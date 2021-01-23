class TestStringSplit
{
    static void Main()
    {
        char[] delimiterChars = { ' ', ',' };
          string text = "www.google.com,www.ggg.com,www.gef.com";
          System.Console.WriteLine("Original text: '{0}'", text);
          string[] words = text.Split(delimiterChars);
          System.Console.WriteLine("{0} urls in text:", words.Length);
          foreach (string s in words)
          {
              System.Console.WriteLine(s + "is url?: " + IsUrlValid(s) );
          }
       }
       
       public static bool IsUrlValid(string text)
       {
            // Url regex.
            string choosen = @"^^(ht|f)tp(s?)\:\/\/[0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&%\$#_=]*)?$";
            return Regex(choosen).IsMatch(text); 
       }
    }
</pre>
