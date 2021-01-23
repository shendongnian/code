    [JsonConverter(typeof(MyCustomConverter))]
    public abstract class BaseClass{
      private class MyCustomConverter : JsonCreationConverter<BaseClass>
      {
         protected override BaseClass Create(Type objectType, 
           Newtonsoft.Json.Linq.JObject jObject)
         {
           //TODO: read the raw JSON object through jObject to identify the type
           //e.g. here I'm reading a 'typename' property:
           if("DerivedType".Equals(jObject.Value<string>("typename")))
           {
             return new DerivedClass();
           }
           return new DefaultClass();
           
           //now the base class' code will populate the returned object.
         }
      }
    }
    public class DerivedClass : BaseClass {
      public string DerivedProperty { get; set; }
    }
    public class DefaultClass : BaseClass {
      public string DefaultProperty { get; set; }
    }
