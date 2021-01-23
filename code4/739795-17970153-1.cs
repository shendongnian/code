    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllText("text.txt");
            var xmlDocuments = Regex
                .Matches(input, @"([0-9AMP: ]*>>Response: )")
                .Cast<Match>()
                .Select(match =>
                    {
                        var currentPosition = match.Index + match.Length;
                        var nextMatch = match.NextMatch();
                        if (nextMatch.Success == true)
                        {
                            return input.Substring(currentPosition,
                                nextMatch.Index - currentPosition);
                        }
                        else
                        {
                            return input.Substring(currentPosition);
                        }
                    })
                .Select(s => XDocument.Parse(s))
                .ToList();
        }
    }
