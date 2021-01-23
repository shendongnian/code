        private static Regex _validAttributeOrTagNameRegEx = 
                           new Regex(@"^\w+$", RegexOptions.Compiled |RegexOptions.IgnoreCase);
            private const string STR_RemoveHtmlAttributeRegex = 
                               @"(?<=<)([^/>]+)(\s{0}=['""][^'""]+?['""])([^/>]*)(?=/?>|\s)";
        public static string RemoveHtmlAttribute(this string input, string attributeName) {
           if (_validAttributeOrTagNameRegEx.IsMatch(attributeName)) {
              Regex reg = new Regex(string.Format(STR_RemoveHtmlAttributeRegex, attributeName),
                 RegexOptions.IgnoreCase);
              return reg.Replace(input, item => item.Groups[1].Value + item.Groups[3].Value);
           } else {
              throw new ArgumentException("Not a valid HTML attribute name", "attributeName");
           }
        }
