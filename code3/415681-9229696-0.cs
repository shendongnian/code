    /// <summary>
    /// 
    /// Generic helper class to convert JSON text to in-memory objects
    /// </summary>
    /// <typeparam name="T">Type of class that the text represents</typeparam>
    public class JSONHandler<T> where T : class, new()
    {
        /// <summary>
        /// Convert a JSON string to an in-memory object of class T.
        /// The class T must be instantiable and not static.
        /// </summary>
        /// <param name="JSONString">JSON string describing the top level object</param>
        /// <returns>Object of class T (and any dependent objects)</returns>
        public T TextToJSON(string JSONString)
        {
            //check that we aren't passing in empty text
            if (String.IsNullOrEmpty(JSONString))
            {
                return null;
            }
            else
            {
                //create a new object
                T JSONObject = new T();
                //and create a new serializer for it
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                //create a memor stream around the text
                System.IO.MemoryStream ms = new System.IO.MemoryStream(Encoding.Unicode.GetBytes(JSONString));
                //do the conversion
                JSONObject = (T)ser.ReadObject(ms);
                //tidy up after ourselves
                ms.Close();
                //and we're done!
                return JSONObject;
            }
        }       
    }
