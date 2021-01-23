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
    
    /// <summary>
    /// Serializes the specified System.Object and returns the serialized XML
    /// </summary>
    /// <typeparam name="T">This item's type</typeparam>
    /// <param name="item">This item</param>
    /// <param name="removeNamespaces">
    ///     <para>Specify whether to remove xml namespaces.</para>para>
    ///     <para>If your object has any XmlInclude attributes, then set this to false</para>
    /// </param>
    /// <returns>Serialized XML for specified System.Object</returns>
    public static string XmlSerialize<T>(this T item, bool removeNamespaces = true)
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
            StringBuilder stringBuilder = new StringBuilder();
            using (StringWriter stringWriter = new StringWriter(stringBuilder))
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, settings))
                {
                    if (removeNamespaces)
                    {
                        xmlSerializer.Serialize(xmlWriter, item, xmlns);
                    }
                    else { xmlSerializer.Serialize(xmlWriter, item); }
    
                    return stringBuilder.ToString();
                }
            }
        }
    }
