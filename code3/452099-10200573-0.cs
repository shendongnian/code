    [JsonObject(MemberSerialization.OptIn)]
    public class Node {
      ...
      [JsonConverter(typeof(Vector2Converter))]
      public Vector2 Position { get; set; }
      ...
    }
