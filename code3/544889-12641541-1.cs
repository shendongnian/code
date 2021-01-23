    [JsonConverter(typeof(MyCustomConverter))]
    public class BaseClass{
      private class MyCustomConverter : JsonCreationConverter<BaseClass>
      {
         protected override FormField Create(Type objectType, 
           Newtonsoft.Json.Linq.JObject jObject)
         {
           //TODO: read the raw JSON object through jObject to identify the type
           //e.g. here I'm reading a 'typename' property:
           if("DerivedType".Equals(jObject.Value<string>("typename"))
             return new DerivedClass();
           else
             return new DefaultClass();
           //now the base class' code will populate the returned object.
         }
      }
    }
