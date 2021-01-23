    using System.Text.RegularExpressions;
    class RegExSample 
    {
      static void Main() 
      {
        string text = "text _$$12 text";
        string result = Regex.Replace(text, @"_\$\$\d+", "#replacement#");
        System.Console.WriteLine("result = [" + result + "]");
      }
    }
