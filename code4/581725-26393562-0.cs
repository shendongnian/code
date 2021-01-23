    /// <summary>
    /// Copy the values contained in the given FormDataCollection into 
    /// a NameValueCollection instance.
    /// </summary>
    /// <param name="formDataCollection">The FormDataCollection instance. (required, but can be empty)</param>
    /// <returns>The NameValueCollection. Never returned null, but may be empty.</returns>
    public static NameValueCollection Convert(FormDataCollection formDataCollection)
    {
        Validate.IsNotNull("formDataCollection", formDataCollection);
        IEnumerator<KeyValuePair<string, string>> pairs = formDataCollection.GetEnumerator();
        NameValueCollection collection = new NameValueCollection();
        while (pairs.MoveNext())
        {
            KeyValuePair<string, string> pair = pairs.Current;
            collection.Add(pair.Key, pair.Value);
        }
        return collection
     }
