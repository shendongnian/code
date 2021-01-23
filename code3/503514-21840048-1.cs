    public class ByteArrayAwareSqliteOrmLiteDialectProvider
		: SqliteOrmLiteDialectProvider {
    
    	public override object ConvertDbValue(object value, Type type) {
    		var bytes = value as byte[];
    		if (bytes != null && type == typeof(byte[]))
    			return bytes;
    
    		return base.ConvertDbValue(value, type);
    	}
    
    	public override string GetQuotedValue(object value, Type fieldType) {
    		var bytes = value as byte[];
    		if (bytes != null && fieldType == typeof(byte[]))
    			return "X'" + BitConverter.ToString(data).Replace("-", "") + "'";
    
    		return base.GetQuotedValue(value, fieldType);
    	}
    
    }
