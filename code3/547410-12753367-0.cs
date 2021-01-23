    public sealed class CustomSerializer<T> : IDataCacheObjectSerializer
    {
		object IDataCacheObjectSerializer.Deserialize(System.IO.Stream stream)
		{       
			DataContractSerializer dcs = new DataContractSerializer(typeof(T));
			return dcs.ReadObject(stream);
		}
		void IDataCacheObjectSerializer.Serialize(System.IO.Stream stream, object value)
		{
			if (!(value is T)) 
			{
				throw new AgrumentException();
			}
			DataContractSerializer dcs = new DataContractSerializer(typeof(T));
			dcs.WriteObject(stream, value);
		}
    }
