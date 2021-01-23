    public class XmlAnnotationReader
	{
		public string XmlPath { get; protected internal set; }
		public XmlDocument Document { get; protected internal set; }
		public XmlAnnotationReader()
		{
			var assembly = Assembly.GetExecutingAssembly();
			string resourceName = String.Format("{0}.App_Data.{0}.XML", assembly.GetName().Name);
			this.XmlPath = resourceName;
			using (Stream stream = assembly.GetManifestResourceStream(resourceName))
			{
				using (StreamReader reader = new StreamReader(stream))
				{
					XmlDocument doc = new XmlDocument();
					//string result = reader.ReadToEnd();
					doc.Load(reader);
					this.Document = doc;
				}
			}
		}
		public XmlAnnotationReader(string xmlPath)
		{
			this.XmlPath = xmlPath;
			if (File.Exists(xmlPath))
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(this.XmlPath);
				this.Document = doc;
			}
			else
				throw new FileNotFoundException(String.Format("Could not find the XmlDocument at the specified path: {0}\r\nCurrent Path: {1}", xmlPath, Assembly.GetExecutingAssembly().Location));
		}
		/// <summary>
		/// Retrievethe XML comments documentation for a given resource
		/// Eg. ITN.Data.Models.Entity.TestObject.MethodName
		/// </summary>
		/// <returns></returns>
		public string GetCommentsForResource(string resourcePath, XmlResourceType type)
		{
			XmlNode node = Document.SelectSingleNode(String.Format("//member[starts-with(@name, '{0}:{1}')]/summary", GetObjectTypeChar(type), resourcePath));
			if (node != null)
			{
				string xmlResult = node.InnerText;
				string trimmedResult = Regex.Replace(xmlResult, @"\s+", " ");
				return trimmedResult;
			}
			return string.Empty;
		}
		/// <summary>
		/// Retrievethe XML comments documentation for a given resource
		/// Eg. ITN.Data.Models.Entity.TestObject.MethodName
		/// </summary>
		/// <returns></returns>
		public ObjectDocumentation[] GetCommentsForResource(Type objectType)
		{
			List<ObjectDocumentation> comments = new List<ObjectDocumentation>();
			string resourcePath = objectType.FullName;
			PropertyInfo[] properties = objectType.GetProperties();
			FieldInfo[] fields = objectType.GetFields();
			List<ObjectDocumentation> objectNames = new List<ObjectDocumentation>();
			objectNames.AddRange(properties.Select(x => new ObjectDocumentation() { PropertyName = x.Name, Type = XmlResourceType.Property }).ToList());
			objectNames.AddRange(properties.Select(x => new ObjectDocumentation() { PropertyName = x.Name, Type = XmlResourceType.Field }).ToList());
			foreach (var property in objectNames)
			{
				XmlNode node = Document.SelectSingleNode(String.Format("//member[starts-with(@name, '{0}:{1}.{2}')]/summary", GetObjectTypeChar(property.Type), resourcePath, property.PropertyName ));
				if (node != null)
				{
					string xmlResult = node.InnerText;
					string trimmedResult = Regex.Replace(xmlResult, @"\s+", " ");
					property.Documentation = trimmedResult;
					comments.Add(property);
				}
			}
			return comments.ToArray();
		}
		/// <summary>
		/// Retrievethe XML comments documentation for a given resource
		/// </summary>
		/// <param name="objectType">The type of class to retrieve documenation on</param>
		/// <param name="propertyName">The name of the property in the specified class</param>
		/// <param name="resourceType"></param>
		/// <returns></returns>
		public string GetCommentsForResource(Type objectType, string propertyName, XmlResourceType resourceType)
		{
			List<ObjectDocumentation> comments = new List<ObjectDocumentation>();
			string resourcePath = objectType.FullName;
			string scopedElement = resourcePath;
			if (propertyName != null && resourceType != XmlResourceType.Type)
				scopedElement += "." + propertyName;
			XmlNode node = Document.SelectSingleNode(String.Format("//member[starts-with(@name, '{0}:{1}')]/summary", GetObjectTypeChar(resourceType), scopedElement));
			if (node != null)
			{
				string xmlResult = node.InnerText;
				string trimmedResult = Regex.Replace(xmlResult, @"\s+", " ");
				return trimmedResult;
			}
			return string.Empty;
		}
		private string GetObjectTypeChar(XmlResourceType type)
		{
			switch (type)
			{
				case XmlResourceType.Field:
					return "F";
				case XmlResourceType.Method:
					return "M";
				case XmlResourceType.Property:
					return "P";
				case XmlResourceType.Type:
					return "T";
					
			}
			return string.Empty;
		}
	}
	public class ObjectDocumentation
	{
		public string PropertyName { get; set; }
		public string Documentation { get; set; }
		public XmlResourceType Type { get; set; }
	}
	public enum XmlResourceType
	{
		Method,
		Property,
		Field,
		Type
	}
