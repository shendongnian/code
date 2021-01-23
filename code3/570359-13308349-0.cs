		public static Byte[] SerializeObject(Object obj)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.TypeFormat = FormatterTypeStyle.TypesWhenNeeded;
			formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
			using(MemoryStream stream = new MemoryStream())
			{
				formatter.Serialize(stream, obj);
				return stream.ToArray();
			}
		}
		public static Object DeserializeObject(Byte[] bytes)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			formatter.TypeFormat = FormatterTypeStyle.TypesWhenNeeded;
			formatter.AssemblyFormat = FormatterAssemblyStyle.Simple;
			using(MemoryStream stream = new MemoryStream(bytes))
				return formatter.Deserialize(stream);
		}
