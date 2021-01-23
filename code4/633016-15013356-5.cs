    public static class Foo {
      public static Message Serialize(object anySerializableObject) {
        using (var memoryStream = new MemoryStream()) {
          (new BinaryFormatter()).Serialize(memoryStream, anySerializableObject);
          return new Message { Data = memoryStream.ToArray() };
        }
      }
      public static object Deserialize(Message message) {
        using (var memoryStream = new MemoryStream(message.Data))
          return (new BinaryFormatter()).Deserialize(memoryStream);
      }
    }
