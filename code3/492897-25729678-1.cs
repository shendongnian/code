    public class NTextSqlProvider : SqlServerOrmLiteDialectProvider
    {
      public new static readonly NTextSqlProvider Instance = new NTextSqlProvider();
      public override string GetColumnDefinition(string fieldName, Type fieldType, 
                bool isPrimaryKey, bool autoIncrement, bool isNullable, 
                int? fieldLength, int? scale, string defaultValue)
      {
         var fieldDefinition = base.GetColumnDefinition(fieldName, fieldType,
                                        isPrimaryKey, autoIncrement, isNullable, 
                                        fieldLength, scale, defaultValue);
         if (fieldType == typeof (string) && fieldLength > 8000)
         {
           var orig = string.Format(StringLengthColumnDefinitionFormat, fieldLength);
           fieldDefinition = fieldDefinition.Replace(orig, "NTEXT");
         }
         return fieldDefinition;
      }
    }
