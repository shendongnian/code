    /// <summary>
    /// Function to get byte array from a object
    /// </summary>
    /// <param name="_Object">object to get byte array</param>
    /// <returns>Byte Array</returns>
    public byte[] ObjectToByteArray(object _Object)
    {
        try
        {
            // create new memory stream
            System.IO.MemoryStream _MemoryStream = new System.IO.MemoryStream();
    
            // create new BinaryFormatter
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter _BinaryFormatter 
                        = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    
            // Serializes an object, or graph of connected objects, to the given stream.
            _BinaryFormatter.Serialize(_MemoryStream, _Object);
            
            // convert stream to byte array and return
            return _MemoryStream.ToArray();
        }
        catch (Exception _Exception)
        {
            // Error
            Console.WriteLine("Exception caught in process: {0}", _Exception.ToString());
        }
    
        // Error occured, return null
        return null;
    }
