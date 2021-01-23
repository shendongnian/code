    public static class XmlExtensions
    {
    	/// <summary>
    	/// Deserializes the XML data contained by the specified System.String
    	/// </summary>
    	/// <typeparam name="T">The type of System.Object to be deserialized</typeparam>
    	/// <param name="s">The System.String containing XML data</param>
    	/// <returns>The System.Object being deserialized.</returns>
    	public static T XmlDeserialize<T>(this string s)
    	{
    		if (string.IsNullOrEmpty(s))
    		{
    			return default(T);
    		}
    
    		var locker = new object();
    		var stringReader = new StringReader(s);
    		var reader = new XmlTextReader(stringReader);
    		try
    		{
    			var xmlSerializer = new XmlSerializer(typeof(T));
    			lock (locker)
    			{
    				var item = (T)xmlSerializer.Deserialize(reader);
    				reader.Close();
    				return item;
    			}
    		}
    		catch
    		{
    			return default(T);
    		}
    		finally
    		{
    			reader.Close();
    		}
    	}
    	
    	/// <summary>
    	/// Deserializes the XML data contained in the specified file.
    	/// </summary>
    	/// <typeparam name="T">The type of System.Object to be deserialized.</typeparam>
    	/// <param name="fileInfo">This System.IO.FileInfo instance.</param>
    	/// <returns>The System.Object being deserialized.</returns>
    	public static T XmlDeserialize<T>(this FileInfo fileInfo)
    	{
    		string xml = string.Empty;
    		using (FileStream fs = new FileStream(fileInfo.FullName, FileMode.Open, FileAccess.Read))
    		{
    			using (StreamReader sr = new StreamReader(fs))
    			{
    				return sr.ReadToEnd().XmlDeserialize<T>();
    			}
    		}
    	}
    	
    	/// <summary>
    	/// <para>Serializes the specified System.Object and writes the XML document</para>
    	/// <para>to the specified file.</para>
    	/// </summary>
    	/// <typeparam name="T">This item's type</typeparam>
    	/// <param name="item">This item</param>
    	/// <param name="fileName">The file to which you want to write.</param>
    	/// <returns>true if successful, otherwise false.</returns>
    	public static bool XmlSerialize<T>(this T item, string fileName)
    	{
    		return item.XmlSerialize(fileName, true);
    	}
    
    	/// <summary>
    	/// <para>Serializes the specified System.Object and writes the XML document</para>
    	/// <para>to the specified file.</para>
    	/// </summary>
    	/// <typeparam name="T">This item's type</typeparam>
    	/// <param name="item">This item</param>
    	/// <param name="fileName">The file to which you want to write.</param>
    	/// <param name="removeNamespaces">
    	///     <para>Specify whether to remove xml namespaces.</para>para>
    	///     <para>If your object has any XmlInclude attributes, then set this to false</para>
    	/// </param>
    	/// <returns>true if successful, otherwise false.</returns>
    	public static bool XmlSerialize<T>(this T item, string fileName, bool removeNamespaces)
    	{
    		object locker = new object();
    
    		XmlSerializerNamespaces xmlns = new XmlSerializerNamespaces();
    		xmlns.Add(string.Empty, string.Empty);
    
    		XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
    
    		XmlWriterSettings settings = new XmlWriterSettings();
    		settings.Indent = true;
    		settings.OmitXmlDeclaration = true;
    
    		lock (locker)
    		{
    			using (XmlWriter writer = XmlWriter.Create(fileName, settings))
    			{
    				if (removeNamespaces)
    				{
    					xmlSerializer.Serialize(writer, item, xmlns);
    				}
    				else { xmlSerializer.Serialize(writer, item); }
    
    				writer.Close();
    			}
    		}
    
    		return true;
    	}
    }
