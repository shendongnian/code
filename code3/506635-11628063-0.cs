    [Serializable]
	public enum MyEnum
	{
	    [EnumMember]
	    ValueA,
		
		[EnumMember]
		ValueB
	}
	
	[Serializable]
	public class Configuration : PersistableObject
	{
	    public double A { get; set; }
		public string B { get; set; }
		public MyEnum C { get; set; }
	}
	
	public class PersistableObject
    {
        public static T Load<T>(string fileName) where T : PersistableObject, new()
        {
            T result = default(T);
            using (FileStream stream = File.OpenRead(fileName))
            {
                result = new XmlSerializer(typeof(T)).Deserialize(stream) as T;
            }
            return result;
        }
		
        public void Save<T>(string fileName) where T : PersistableObject
        {
            using (FileStream stream = new FileStream(fileName, FileMode.CreateNew))
            {
                new XmlSerializer(typeof(T)).Serialize(stream, this);
            }
        }
    }
