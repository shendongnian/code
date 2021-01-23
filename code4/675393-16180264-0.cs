      public SerializedResults SerializeResults(Type queryType, IEnumerable entities)
      {
          var results = SerializeDynamicType(queryType);
          var objList = AnonymousFns.DeconstructMany(entities, false, queryType).ToList();
          var ms = new MemoryStream();         
          using (ms)
          {
              using (GZipStream compress = new GZipStream(ms, CompressionMode.Compress, CompressionLevel.BestCompression))
              {
                using( BsonWriter writer = new BsonWriter(compress))
                {
                  JsonSerializer serializer = new JsonSerializer();                 
                  serializer.Serialize(writer, objList);
                }
              }
          }
          results.ByteArray = ms.ToArray();
          return results;
      }
