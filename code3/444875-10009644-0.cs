    using System.Text.RegularExpressions;
    class Program {
        static void Main(string[] args) {
            string toReplace = "This is a sentence with **multiple** strong tags which will be **strong** upon output";
            int index = 0;
            string replaced = Regex.Replace(toReplace, @"\*\*", (m) => {
                index++;
                if (index % 2 == 1) {
                    return "<strong>";
                } else {
                    return "</strong>";
                }
            });
        }
    }
