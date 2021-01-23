        {
             if (formattedValue != DBNull.Value && formattedValue.ToString() != "")
            {
                return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter,
                    valueTypeConverter);
            }
             else
             {
                 return DBNull.Value;
             }
        }
