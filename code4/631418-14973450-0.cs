    private void TestFunc()
        {
            var patternEmail = @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";
            var all = ExtactMatches(patternEmail, piWorkitem.SupplierConsultant, piWorkitem.ResponsibleConsultant);
        }
        private IEnumerable<string> ExtactMatches(string pattern, params string[] srcText)
        {
            HashSet<string> emailaddresses = new HashSet<string>();
            foreach (var text in srcText)
            {
                //Get emails from ResponsibleConsultant
                var emailCollection1 = Regex.Matches(text, pattern);
                foreach (Match mail in emailCollection1.Cast<Match>().Where(mail => !emailaddresses.Contains(mail.Value.ToString(CultureInfo.InvariantCulture))))
                {
                    emailaddresses.Add(mail.Value);
                }
            }
            return emailaddresses;
        }
