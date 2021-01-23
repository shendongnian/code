    public static List<TEntity> Clone<TEntity>(List<TEntity> original)
    {
       List<TEntity> returnValue = null;
       using (var stream = new System.IO.MemoryStream())
       {
          var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
          //serialize to stream 
          binaryFormatter.Serialize(stream, original);           
          stream.Position = 0;
          //deserialize from stream.
          returnValue = binaryFormatter.Deserialize(stream) as List<TEntity>;
       }
       return returnValue;
    }
