        private static string StripComments(string input)
        {
            // JavaScriptSerializer doesn't accept commented-out JSON, so we'll strip them out ourselves;
            // NOTE: for safety and simplicity, we only support comments on their own lines, not sharing lines with real JSON
            input = Regex.Replace(input, @"^\s*//.*$", "", RegexOptions.Multiline);  // removes comments like this
            input = Regex.Replace(input, @"^\s*/\*(\s|\S)*?\*/\s*$", "", RegexOptions.Multiline); /* comments like this */
            return input;
        }
