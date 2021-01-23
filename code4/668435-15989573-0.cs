        public string FixEscapeCharacterSequence(string query)
        {
            query = query.Replace("'", "\'");
            return query;
        }
