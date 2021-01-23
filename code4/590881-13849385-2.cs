    namespace a
    {
        class Program
        {
            static void Main(string[] args)
            {
                string X = System.IO.File.ReadAllText("C:\\Users\\rnirnberger\\Documents\\a.txt");
                System.Text.RegularExpressions.Regex Y = new System.Text.RegularExpressions.Regex("{{(.*?)\\}}");
                System.Text.RegularExpressions.MatchCollection Z = Y.Matches(X);
                foreach (System.Text.RegularExpressions.Match match in Z)
                {
                    Console.WriteLine(match.Value);
    
                    //If you want to strip out the double-braces
                    //↓↓↓↓
    
                    //Console.WriteLine(match.Value.Replace("{{", "").Replace("}}", ""));
                }
            }
        }
