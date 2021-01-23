      public class Foo
      {
          [JsonConverter(typeof(DbGeographyGeoJsonConverter))]
          public DbGeography Polygon { get; set; }
      }
