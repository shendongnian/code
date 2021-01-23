		public static T DeepClone<T>(this T a)
		{
			using (MemoryStream stream = new MemoryStream())
			{
				DataContractSerializer dcs = new DataContractSerializer(typeof(T));
				XmlDictionaryWriter writer = XmlDictionaryWriter.CreateBinaryWriter(stream);
				dcs.WriteObject(writer, a);
				stream.Position = 0;
				return (T)dcs.ReadObject(stream);
			}
		}
