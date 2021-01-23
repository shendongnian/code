    using System;
    using System.Text.RegularExpressions;
    public class Replacer
    {
        public string Replace(string input)
        {
            // The regular expression passed as the second argument to the Replace method
            // matches strings in the format "{value0#value1/value2}", i.e. three strings
            // separated by "#" and "/" all surrounded by braces.
            var result = Regex.Replace(
                input,
                @"{(?<value0>[^#]+)#(?<value1>[^/]+)/(?<value2>[^}]+)}",
                ReplaceMatchEvaluator);
            return result;
        }
        private string ReplaceMatchEvaluator(Match m)
        {
            // m.Value contains the matched string including the braces.
            // This method is invoked once per matching portion of the input string.
            // We can then extract each of the named groups in order to access the
            // substrings of each matching portion as follows:
            var value0 = m.Groups["value0"].Value; // Contains first value, e.g. "Jwala Vora"
            var value1 = m.Groups["value1"].Value; // Contains second value, e.g. "3"
            var value2 = m.Groups["value2"].Value; // Contains third value, e.g. "13"
            // Here we can do things like convert value1 and value2 to integers...
            var intValue1 = Int32.Parse(value1);
            var intValue2 = Int32.Parse(value2);
            // etc.
            // Here we return the value with which the matching portion is replaced.
            // This would be some function of value0, value1 and value2 as well as
            // any other data in the Replacer class.
            return "xyz";
        }
    }
    public static class Program
    {
        public static void Main(string[] args)
        {
            var replacer = new Replacer();
            var result = replacer.Replace("Proposal is given to {Jwala Vora#3/13} for {Amazon Vally#2/11} {1#3/75} by {MdOffice employee#1/1}");
            Console.WriteLine(result);
        }
    }
