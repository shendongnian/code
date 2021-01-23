    public class OracleOrmLiteDialectProvider : OrmLiteDialectProviderBase<OracleOrmLiteDialectProvider>
    ... 
		public override string GetQuotedValue(object value, Type fieldType)
		{
    ... 
 			if (fieldType == typeof(byte[]))
			{
				var bytes = value as byte[];
				return "to_blob (utl_raw.cast_to_raw('" + Encoding.UTF8.GetString(bytes)+ "'))";
			}
    ...
    }
