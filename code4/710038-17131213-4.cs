      static string[] GetLines(string text)
      {
         return text.Replace("\r", "").Split('\n');
      }
      
      static string GetLine(string[] lines, int lineNo)
      {
          return lines.Length >= lineNo ? lines[lineNo - 1] : null;
      }
     static void Main(string[] args)
     {
       string file = "D:\\random.text";
       string contents = "";
       string text="random";
       contents = File.ReadAllText(file);
       var lines = GetLines(contents);
       finale = GetLine(lines, lineNo);
       //Console.ReadLine();
       if (finale == null)
           return;
        if(finale.Contains(text))
        {
            finale = finale.Replace(text, "Random");
            System.Console.WriteLine(finale);
            Console.ReadLine();
        }
        lines[lineNo] = finale;
        contents = string.Join('\n', lines);
     }
