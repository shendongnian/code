    public class Keys
    {
      [BsonElement("key1")]
      public int Key1;
      [BsonElement("key2")]
      public int key2;
    }
    
    public class values
    {
      [BsonElement("val1")]
      public int Val1;
      [BsonElement("val1")]
      public int Val2;
      [BsonElement("val1")]
      public int Val3;
    }
    
    public class MapReduceOutput
    {
      [BsonId]
      public Keys Keys;
      [BsonElement("values")]
      public Values Values;
    }
