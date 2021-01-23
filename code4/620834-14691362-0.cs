    namespace Newtonsoft.Json
    {
    	public class DictionaryConverter<tKey, tValue>: JsonConverter
    	{
    		public override bool CanRead { get { return true; } }
    		public override bool CanWrite { get { return true; } }
    
    		public override bool CanConvert( Type objectType )
    		{
    			if( !objectType.IsGenericType )
    				return false;
    			if( objectType.GetGenericTypeDefinition() != typeof( Dictionary<,> ) )
    				return false;
    			Type[] argTypes = objectType.GetGenericArguments();
    			if( argTypes.Length != 2 || argTypes[ 0 ] != typeof( tKey ) || argTypes[ 1 ] != typeof( tValue ) )
    				return false;
    			return true;
    		}
    
    		public override object ReadJson( JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer )
    		{
    			do
    			{
    				if( JsonToken.StartObject != reader.TokenType )
    					break;
    				Dictionary<tKey, tValue> res = new Dictionary<tKey, tValue>();
    
    				while( reader.Read() )
    				{
    					if( JsonToken.EndObject == reader.TokenType )
    						return res;
    					if( JsonToken.PropertyName == reader.TokenType )
    					{
    						tKey key = (tKey)Convert.ChangeType( reader.Value, typeof( tKey ), null );
    						if( !reader.Read() )
    							break;
    						tValue val = serializer.Deserialize<tValue>( reader );
    						res[ key ] = val;
    					}
    				}
    			}
    			while( false );
    			throw new Exception( "unexpected JSON" );
    		}
    
    		public override void WriteJson( JsonWriter writer, object value, JsonSerializer serializer )
    		{
    			if( null == value )
    				return;
    			Dictionary<tKey, tValue> src = value as Dictionary<tKey, tValue>;
    			if( null == src )
    				throw new Exception( "Expected Dictionary<{0}, {1}>".FormatWith( typeof( tKey ).Name, typeof( tValue ).Name ) );
    
    			writer.WriteStartObject();
    			foreach (var kvp in src)
    			{
    				string strKey = (string)Convert.ChangeType( kvp.Key, typeof( string ), null );
    				writer.WritePropertyName( strKey );
    				serializer.Serialize( writer, kvp.Value );
    			}
    			writer.WriteEndObject();
    		}
    	}
    }
