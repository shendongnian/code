		/// <summary>
		/// Given a serializable object, returns an XML string representing that object.
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string Serialize(object obj)
		{
			XmlSerializer xs = new XmlSerializer(obj.GetType());
			using (MemoryStream buffer = new MemoryStream())
            {
			  xs.Serialize(buffer, obj);
			  return ASCIIEncoding.ASCII.GetString(buffer.ToArray());
            }
		}
