    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    class Program {
        static void Main(string[] args) {
            string value = "one or:another{3}";
            StringBuilder sb = new StringBuilder();
            Regex exclude = new Regex(@"\d|\s|/|-", RegexOptions.Compiled);
            string final = string.Join(" ",
                (from s in Regex.Split(value, "([ \\t{}():;.,،\"\n])")
                    where s.Length > 2 && !exclude.IsMatch(s)
                    select s).ToArray());
        }
    }
