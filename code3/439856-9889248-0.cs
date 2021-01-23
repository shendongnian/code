    public class SerializeDeserializeExample {
       public string Serialize(object objectToSerialize) {
          using(var stream = new MemoryStream()) {
             new BinaryFormatter().Serialize(stream, objectToSerialize);
             return Convert.ToBase64String(stream.ToArray());
          }
       }
       public object Deserialize(string base64String) {
          using(var stream = new MemoryStream(Convert.FromBase64String(base64String))) {
             var formatter = new BinaryFormatter();
             var surrogateSelector = new SurrogateSelector();
             formatter.SurrogateSelector = surrogateSelector;
             formatter.Binder = new DeserializationBinder(surrogateSelector);
             return formatter.Deserialize(stream);
          }
       }
    }
    public class MyDeserializationBinder : SerializationBinder {
       private readonly SurrogateSelector surrogateSelector;
       public MyDeserializationBinder(SurrogateSelector surrogateSelector) {
          this.surrogateSelector = surrogateSelector;
       }
       public override Type BindToType(string assemblyName, string typeName) {
          if(typeName.Equals("MyOldClass", StringComparison.InvariantCultureIgnoreCase)) {
             return RemapToType();
          }
          return Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
       }
       private Type RemapToType() {
          var remapToType = typeof(MyNewClass);
          surrogateSelector.AddSurrogate(remapToType,
                                  new StreamingContext(StreamingContextStates.All),
                                  new MyCustomDeserializationSurrogate());
          return remapToType;
       }
    }
    public sealed class MyCustomDeserializationSurrogate : ISerializationSurrogate {
       public void GetObjectData(Object obj, SerializationInfo info, StreamingContext context) {
          throw new NotImplementedException();
       }
       public Object SetObjectData(Object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector) {
          var objectType = obj.GetType();
          var fields = GetFields(objectType);
          foreach(var fieldInfo in fields) {
             var fieldValue = info.GetValue(fieldInfo.Name, fieldInfo.FieldType);
             fieldValue = DoSomeProcessing(fieldValue);
             fieldInfo.SetValue(obj, fieldValue);
          }
          return obj;
       }
       private static IEnumerable<FieldInfo> GetFields(Type objectType) {
          return objectType.GetFields(BindingFlags.Instance | BindingFlags.DeclaredOnly |
                               BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
       }
       
       private static object DoSomeProcessing(object value){
          //Do some processing with the object
       }
    }
