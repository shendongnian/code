        public string GetPersonNames
        {
            get
            {
                return string.Join(",", persons.Select(p => p.name));
            }
        }
