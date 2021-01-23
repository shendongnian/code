    static void Main(string[] args)
            {
                string myString = "\"test\" test1 \"test2 test3\" test4 test6 \"test5\"";
                string myRegularExpression = @"""(.*?)""";
                List<string> listOfMatches = new List<string>();
    
                myString = Regex.Replace(myString, myRegularExpression, delegate(Match match)
                {
                    string v = match.ToString();
                    listOfMatches.Add(v);
                    return "";
                });
    
                var array = myString.Split(' ');
                foreach (string s in array)
                {
                    if(s.Trim().Length > 0)
                        listOfMatches.Add(s);
                }
    
                foreach (string match in listOfMatches)
                {
                    Console.WriteLine(match);
                }
                Console.Read();
    
            }
