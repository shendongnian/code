    using System.Linq;
    using System.Text.RegularExpressions;
    static class Program {
        static void Main(string[] aargs) {
            string value = "I have a dog and a cat.";
            Regex regex = new Regex("dog|cat");
            var matchesList = (from Match m in regex.Matches(value) select m.Value).ToList();
        }
    }
