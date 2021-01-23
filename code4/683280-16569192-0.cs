        public void _set_WORKS(string columnName, string value, string newColumnName, string newValue) {
             var output = this.AsEnumerable()
                .Where(s => s.Field<string>(columnName).Equals(value))
                .FirstOrDefault();
            output.SetField<string>(newColumnName, newValue);
        }
