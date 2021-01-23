         Dictionary<string, string> constValues = new Dictionary<string, string>()
                                                             {
                                                                 {"MSG_1", "New error {0}"},
                                                                 {"MSG_2", "Random error occurred {1}"}
                                                             };
        public string GetNewType(string MType)
        {
            if (constValues.ContainsKey(MType))
                return constValues[MType];
            return string.Empty;
        }
