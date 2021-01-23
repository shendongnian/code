    		public static SerializableBusinessCard DeserializeBusinessCardXML(string filename)
    		{
    			SerializableBusinessCard result = new SerializableBusinessCard();
    			using(StreamReader streamReader = new StreamReader(filename))
    			{
    				XmlSerializer xmlReader = new XmlSerializer(typeof(SerializableBusinessCard));
    				result = (SerializableBusinessCard) xmlReader.Deserialize(streamReader);
    			}
    			return result;
    		}
