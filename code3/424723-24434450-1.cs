    public override object ParseFormattedValue(object formattedValue, DataGridViewCellStyle cellStyle,TypeConverter formattedValueTypeConverter, TypeConverter valueTypeConverter)
    {
      if (formattedValue != DBNull.Value && formattedValue.ToString() != "")
      {
        return base.ParseFormattedValue(formattedValue, cellStyle, formattedValueTypeConverter, valueTypeConverter);
      }
      else
      {
        return DBNull.Value;
      }
    }
