        /// <summary>
        /// Quotes a string using the following rules:
        /// <list>
        /// <listheader>Rules</listheader>
        /// <item>if the string is not quoted and the string contains the separator string</item>
        /// <item>if the string is not quoted and the string begins or ends with a space</item>
        /// <item>if the string is not quoted and the string contains CrLf</item>
        /// </list>
        /// </summary>
        /// <param name="s">String to be quoted</param>
        /// <param name="quote">
        /// <list>
        /// <listheader>quote characters</listheader>
        /// <item>if len = 0 then double quotes assumed</item>
        /// <item>if len = 1 then quote string is doubled for left and right quote characters</item>
        /// <item>else first character is left quote, second character is right quote</item>
        /// </list>
        /// </param>
        /// <param name="sep">separator string to check against</param>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string QuoteName(this string s, string quote = null, string sep = ",")
        {
            quote = quote == null ? "" : quote;
            switch (quote.Length)
            {
                case 0:
                    quote = "\"\"";
                    break;
                case 1:
                    quote += quote;
                    break;
            }
            // Fields with embedded sep are quoted
            if ((!s.StartsWith(quote.Substring(0, 1))) && (!s.EndsWith(quote.Substring(1, 1))))
                if (s.Contains(sep))
                    s = quote.Substring(0, 1) + s + quote.Substring(1, 1);
            // Fields with leading or trailing blanks are quoted
            if ((!s.StartsWith(quote.Substring(0, 1))) && (!s.EndsWith(quote.Substring(1, 1))))
                if (s.StartsWith(" ") || s.EndsWith(" "))
                    s = quote.Substring(0, 1) + s + quote.Substring(1, 1);
            // Fields with embedded CrLF are quoted
            if ((!s.StartsWith(quote.Substring(0, 1))) && (!s.EndsWith(quote.Substring(1, 1))))
                if (s.Contains(System.Environment.NewLine))
                    s = quote.Substring(0, 1) + s + quote.Substring(1, 1);
            return s;
        }
        public static string GetCSV(this IQueryable entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            Type T = entity.ElementType;
            var props = T.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var sb = new StringBuilder();
            int iCols = props.Count();
            try
            {
                sb.Append(string.Join(",", Enumerable.Range(0, iCols).Cast<int>().
                    Select(ii => props[ii].Name.QuoteName("[]")).ToArray()));
                foreach (var dr in entity)
                {
                    sb.AppendLine();
                    sb.Append(string.Join(",", Enumerable.Range(0, iCols).Cast<int>().
                        Select(ii => props[ii].GetValue(dr).
                            ToString().QuoteName("\"\"", ",")).ToArray()));
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return sb.ToString();
        }
    }
