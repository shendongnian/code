    using System.Text.RegularExpressions;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string str = "asjfaieprnv{1}oiuwe{}hern{0}oaiwefn";
                Regex regex = new Regex(@"\{(.*?)\}");
    
                foreach( Match match in regex.Matches(str))
                {
                     Console.WriteLine(match.Groups[1].Value);
                }
            }
        }
    }
