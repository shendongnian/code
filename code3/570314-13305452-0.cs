    using System.Text.RegularExpressions;
    static class Program {
        static void Main(string[] args) {
            string strToReplaceIn = "Hello, I need to replace startingCharsWITH_SOMETHINGendingChars, ....";
            string replaced = Regex.Replace(strToReplaceIn, "startingChars(?<contents>.*?)endingChars", (match) => {
                return "myFunctionResult(" + match.Groups["contents"].Value + ")";
            });
        }
    }
