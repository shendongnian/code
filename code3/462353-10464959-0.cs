    using System.Linq;
    using System.Text.RegularExpressions;
    class Program {
        static void Main() {
            string text = "12 text text 7 text";
            int[] numbers = (from Match m in Regex.Matches(text, @"\d+") select int.Parse(m.Value)).ToArray();
        }
    }
