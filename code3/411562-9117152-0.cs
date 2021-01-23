        public static object TryParseSqlValue(this object input)
        {
            if (null == input)
                return DBNull.Value;
            if (input.GetType() == typeof(string) && input.ToString() == string.Empty)
                return DBNull.Value;
            else
                return input;
        }
    myTextBox.Text.TryParseSqlValue();  // returns either the non-empty 
                                        // string or DBNull.Value
