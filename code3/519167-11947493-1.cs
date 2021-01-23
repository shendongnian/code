    /// <summary>
    /// XMLs the string to object.
    /// </summary>
    /// <typeparam name="T">Object of target type</typeparam>
    /// <param name="xml">The XML.</param>
    /// <returns>Instance of target type object filled with corresponding xml data.</returns>
    public static T XMLStringToObject<T>(string xml)
    {
        // create default instance of the target type object
        T targetObject = default(T);
        // init serializer params
        XmlSerializer ser = null;
        StringReader stringReader = null;
        XmlTextReader xmlReader = null;
        try
        {
            // start deserialization of object 
            ser = new XmlSerializer(typeof(T));
            stringReader = new StringReader(xml);
            xmlReader = new XmlTextReader(stringReader);
            targetObject = (T)ser.Deserialize(xmlReader);
        }
        catch(Exception ex)
        {
            // determine what type of object was the target and a copy of the xml being tried and rethrow
            throw new ArgumentException(String.Format("Exception while deseriliazing to object of type {0}.\n\n=== XML ========\n{1}", typeof(T), xml), ex);
        }
        finally
        {
            // always close readers to release objectToXMLString
            xmlReader.Close();
            stringReader.Close();
        }
        
        // return target objectToXMLString
        return targetObject;
    }
