	// using System.Runtime.Serialization;
	public class Cloner<T>
	{
		readonly DataContractSerializer _serializer 
				= new DataContractSerializer(typeof(T));
		/// <summary>
		/// Clone an object graph
		/// </summary>
		/// <param name="graph"></param>
		/// <returns></returns>
		public T Clone(T graph)
		{
			MemoryStream stream = new MemoryStream();
			_serializer.WriteObject(stream, graph);
			stream.Seek(0, SeekOrigin.Begin);
			return (T)_serializer.ReadObject(stream);
		}
	}
	
