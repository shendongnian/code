    using System.Linq;
    using System.Text;
    static class Program {
        static void Main(string[] args) {
            const string removeChars = " ?&^$#@!()+-,:;<>’\'-_*";
            string result = "x&y(z)";
            // specify capacity of StringBuilder to avoid resizing
            StringBuilder sb = new StringBuilder(result.Length);
            foreach (char x in result.Where(c => !removeChars.Contains(c))) {
                sb.Append(x);
            }
            result = sb.ToString();
        }
    }
