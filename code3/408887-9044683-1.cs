        public string FormatQuery(string query)
        {
            query = query.Replace('\'', '\"');
            string[] operators = new string[] { "<", ">", "!=", "<=", ">=", "<>", "=" };
            string[] parts = query.Split();
            for (int i = 0; i < parts.Length; i++)
            {
                if (operators.Contains(parts[i]))
                {
                    parts[i - 1] = "it[\"" + parts[i - 1] + "\"]";
                }
            }
            return String.Join(" ", parts);
        }
