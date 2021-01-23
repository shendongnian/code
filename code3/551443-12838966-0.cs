        public static T FromXml<T>(string xml)
        {
           string convertedXml = AddNilAttributesToNullableTypesWithNullValues(typeof(T), xml);
           var reader = new StringReader(convertedXml);
           var serializer = new XmlSerializer(typeof (T));
           var data = (T) serializer.Deserialize(reader);
           reader.Close();
           return data;
        }
		private static string AddNilAttributesToNullableTypesWithNullValues(Type type, string xml)
		{
			string result;
			if (!string.IsNullOrWhiteSpace(xml))
			{
				XDocument doc = XDocument.Parse(xml);
				if (doc.Root != null)
					AddNilAttributesToNullableTypesWithNullValues(doc.Root, type);
				result = doc.ToString();
			}
			else
				result = xml;
			return result;
        }
        private static void AddNilAttributesToNullableTypesWithNullValues(XElement element, Type type)
		  {
			 if (type == null)
				throw new ArgumentNullException("type");
			 if (element == null)
				throw new ArgumentNullException("element");
			 //If this type can be null and it does not have a value, add or update nil attribute
			 //with a value of true.
			 if (IsReferenceOrNullableType(type) && string.IsNullOrEmpty(element.Value))
			 {
				XAttribute existingNilAttribute = element.Attributes().FirstOrDefault(a => a.Name.LocalName == NIL_ATTRIBUTE_NAME);
				
				if (existingNilAttribute == null)
				   element.Add(NilAttribute);
				else
				   existingNilAttribute.SetValue(true);
			 }
			 else
			 {
				//Process all of the objects' properties that have a corresponding child element.
				foreach (PropertyInfo property in type.GetProperties())
				{
				   string elementName = GetElementNameByPropertyInfo(property);
				   foreach (XElement childElement in element.Elements().Where(e =>
					  e.Name.LocalName.Equals(elementName)))
				   {
					  AddNilAttributesToNullableTypesWithNullValues(childElement, property.PropertyType);
				   }
				}
				//For generic IEnumerable types that have elements that correspond to the enumerated type,
				//process the each element.
				if (IsGenericEnumerable(type))
				{
				   Type enumeratedType = GetEnumeratedType(type);
				   if (enumeratedType != null)
				   {
					  IEnumerable<XElement> enumeratedElements = element.Elements().Where(e =>
						 e.Name.LocalName.Equals(enumeratedType.Name));
					  foreach (XElement enumerableElement in enumeratedElements)
						 AddNilAttributesToNullableTypesWithNullValues(enumerableElement, enumeratedType);
				   }
				}
			 }
		  }
		  private static string GetElementNameByPropertyInfo(PropertyInfo property)
		  {
			 string overrideElementName = property.GetCustomAttributes(true).OfType<XmlElementAttribute>().Select(xmlElementAttribute => 
				xmlElementAttribute.ElementName).FirstOrDefault();
			 return overrideElementName ?? property.Name;
		  }
		  private static Type GetEnumeratedType(Type type)
		  {
			 Type enumerableType = null;
			 Type[] types = type.GetGenericArguments();
			 if (types.Length == 1)
				enumerableType = types[0];
			 return enumerableType;
		  }
		  public static bool IsGenericEnumerable(Type type)
		  {
			 return type.IsGenericType && type.GetInterfaces().Any(i => 
				i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEnumerable<>));
		  }
		  private static bool IsReferenceOrNullableType(Type type)
		  {
			 return !type.IsValueType || Nullable.GetUnderlyingType(type) != null;
		  }
          private const string NIL_ATTRIBUTE_NAME = "nil";
          private const string XML_SCHEMA_NAMESPACE = "http://www.w3.org/2001/XMLSchema-instance";
		  private static XAttribute NilAttribute
          {
             get
             {
                 if (_nilAttribute == null)
                 {
                     XNamespace xmlSchemaNamespace = XNamespace.Get(XML_SCHEMA_NAMESPACE);
                     _nilAttribute = new XAttribute(xmlSchemaNamespace + NIL_ATTRIBUTE_NAME, true);
             }
            return _nilAttribute;
         }
      }
