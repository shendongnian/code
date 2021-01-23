    public class Bar : IXmlSerializable, IEnumerable
	{
		public XmlSchema GetSchema() { return null; }
		private List<T> barList;
		public void ReadXml(XmlReader reader)
		{
			XmlSerializer S = new XmlSerializer(typeof(Bar));
		
			reader.Read();
  
			while(reader.NodeType != XmlNodeType.EndElement)
			{
				T item = (T) S.Deserialize(reader);
				if(item != null)
					Add(item);
			}
		
			reader.ReadEndElement();
		}
		public void WriteXml(XmlWriter writer)
		{
			XmlSerializer S = new XmlSerializer(typeof(T));
			foreach(T item in barList)
			{
				S.Serialize(writer, item, null); //Last parameter is namespace
			}
		}
		public IEnumerator GetEnumerator()
		{
    		return barList.GetEnumerator();
		}
		public void Add(T item)
		{
			barList.Add(item);
		}
		public void Add(TChild item)
		{
			barList.Add(item);
		}
	}
