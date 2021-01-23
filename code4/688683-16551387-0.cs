    	public class ArrayOfstring
    	{
    		[XmlElement("string")]
    		public List<string> strings;
    	}
    
        private void Deserialize(string xmlString)
    	{
    		var serializer = new XmlSerializer(typeof(ArrayOfstring));
    	    var reader = new StringReader(xmlString);
    		var GenreList = ((ArrayOfstring) serializer.Deserialize(reader)).strings;
        }
