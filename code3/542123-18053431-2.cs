		public void SerializeObjectXML(string filename,object obj)
		{
			using(StreamWriter streamWriter = new StreamWriter(filename))
			{
				XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
				xmlSerializer.Serialize(streamWriter,obj);
			}
		}
