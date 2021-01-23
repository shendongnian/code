      public class GenericTypeExtension : MarkupExtension
      {
        public GenericTypeExtension()
        {
    
        }
        public GenericTypeExtension(string baseTypeName_, Type genericType1_, Type genericType2_, Type genericType3_)
        {
          BaseTypeName = baseTypeName_;
          GenericType1 = genericType1_;
          GenericType2 = genericType2_;
          GenericType3 = genericType3_;
        }
        public string BaseTypeName { get; set; }
        public string BaseTypeAssemblyName { get; set; }
        public Type GenericType1 { get; set; }
        public Type GenericType2 { get; set; }
        public Type GenericType3 { get; set; }
    
        public override object ProvideValue(IServiceProvider serviceProvider_)
        {
          var list = new List<Type>();
          if (GenericType1 != null)
          {
            list.Add(GenericType1);
          }
          if (GenericType2 != null)
          {
            list.Add(GenericType2);
          }
          if (GenericType3 != null)
          {
            list.Add(GenericType3);
          }
    
          var type = Type.GetType(string.Format("{0}`{1}, {2}", BaseTypeName, list.Count, BaseTypeAssemblyName));
          if (type != null)
          {
            return type.MakeGenericType(list.ToArray());
          }
          return null;
        }
    
      }
