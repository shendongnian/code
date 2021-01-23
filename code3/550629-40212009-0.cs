			public static void Serialize<T>(T obj, string path)
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
				Stream stream = File.OpenWrite(path);
				serializer.WriteObject(stream, obj);
			}
			public static T Deserialize<T>(string path)
			{
				DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
				Stream stream = File.OpenRead(path);
				return (T)serializer.ReadObject(stream);
			}
