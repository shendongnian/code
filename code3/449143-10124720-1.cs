    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    class Program {
      static void Main() {
        // Arbirary cutoff used to join short strings.
        const int Cutoff = 6;
        string input =
          "\r\n\r\n\n\r\r\r\n\nthisisatest\r\nstring\r\nwith\nsome\r\n" + 
          "unsanatized\r\nbreaks\r\nand\ra\nsh\nor\nt\r\n\na\na\na\na" +
          "\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na\na";
        input = (input ?? String.Empty).Trim(); // Don't forget to HtmlEncode it.
        StringBuilder temp = new StringBuilder();
        List<string> result = new List<string>();
        var items = input.Split(
                            new[] { '\r', '\n' },
                            StringSplitOptions.RemoveEmptyEntries)
                         .Select(i => new { i.Length, Value = i });
        foreach (var item in items) {
          if (item.Length > Cutoff) {
            if (temp.Length > 0) {
              result.Add(temp.ToString());
              temp.Clear();
            }
            result.Add(item.Value);
            continue;
          }
          if (temp.Length > 0) { temp.Append(" "); }
          temp.Append(item.Value);
        }
        if (temp.Length > 0) {
          result.Add(temp.ToString());
        }
        Console.WriteLine(String.Join("<br />", result));
      }
    }
