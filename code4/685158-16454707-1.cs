            static void Main(string[] args)
            {
                IEnumerable<string> textLines = Directory.GetFiles(@"C:\testlocation\", "*.*")
                                 .Select(filePath => File.ReadLines(filePath))
                                 .SelectMany(line => line);
    
                //List<string> users = new List<string>();
                //Regex r = new Regex("^.*WX\\sADVSearch(.*)50\\]$");
                string text = String.Join("",textLines.ToArray());
                
                MatchCollection mcol = Regex.Matches(text,"(?<=method\:)([^ ]+)");
                //foreach (string Line in textLines)
                //{
                //    if (r.IsMatch(Line))
                //    {
                //        users.Add(Line);
                //    }
                //}
                //string[] textLines1 = new List<string>(users).ToArray();
                int countlines = mcol.Count; //textLines1.Count();
                Console.WriteLine("WX_ADVSearch=" + countlines);
                // keep screen from going away
                // when run from VS.NET
                Console.ReadLine();
            }
