        public static string ClearSubject(string originalSubject)
        {
            Regex regex = new Regex(@"^([\[\(] *)?(RE?S?|FYI|RIF|I|FS|VB|RV|ENC|ODP|PD|YNT|ILT|SV|VS|VL|AW|WG|ΑΠ|ΣΧΕΤ|ΠΡΘ|תגובה|הועבר|主题|转发|FWD?) *([-:;)\]][ :;\])-]*|$)|\]+ *$", RegexOptions.IgnoreCase);
            originalSubject = regex.Replace(originalSubject, string.Empty);
            if (regex.IsMatch(originalSubject))
            {
                return ClearSubject(originalSubject);
            }
            return originalSubject;
        }
