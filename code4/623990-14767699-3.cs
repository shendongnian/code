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
                @"\{(?P<value0>.+)#(?<value1>.+)/(?<value2>.+)\}"),
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
            // This would be some function of the substrings.
            return "some function of value0, value1 and value2";
        }
    }
