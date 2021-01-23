		/// <summary>
		/// Convert an instance from xml to object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="xml"></param>
		/// <returns></returns>
		public static T Deserialize<T>(string xml)
		{
			if (String.IsNullOrEmpty(xml))
				return default(T);
			try
			{
				XmlSerializer XS = new XmlSerializer(typeof(T));
				System.IO.StringReader SR = new System.IO.StringReader(xml);
				XmlTextReader xmlReader = new XmlTextReader(SR);
				return (T)XS.Deserialize(xmlReader);
			}
			catch (Exception e)
			{
				Logging.Log(Severity.Error, String.Format("Error deserializing xml: {0}", xml), e);
				return default(T);
			}
		}
