        public static string MySqlEscape(Object usString)
        {
            if (usString is DBNull)
            {
                return "";
            }
            else
            {
                string sample = Convert.ToString(usString);
                return Regex.Replace(sample, @"[\r\n\x00\x1a\\'""]", @"\$0");
            }
        }
