    using System;
    using System.Text.RegularExpressions;
    class Program {
      static void Main() {
        string input = "\r\n\r\n\n\r\r\r\n\nthisisatest\r\nstring\r\nwith\nsome" +
                       "\r\nunsanatized\r\nbreaks\r\n\r\n";
        input = (input ?? String.Empty).Trim().Replace("\r", String.Empty);
        string output = Regex.Replace(
                          input,
                          "\\\n+",
                          "<br />",
                          RegexOptions.Multiline);
        Console.WriteLine(output);
      }
    }
