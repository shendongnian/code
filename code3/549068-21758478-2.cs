    public class DynamicContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, 
            MemberSerialization memberSerialization)
        {
       		Func<Type,bool> includeProperty = t => t.IsValueType || t.Namespace.StartsWith("System") && t.Namespace.StartsWith("System.Data")==false; 
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
     		var allProperties = properties.Select (p => new{p.PropertyName,Including=includeProperty(p.PropertyType), p.PropertyType});//.Dump("props");
    		var warnProperties=allProperties.Where (a =>a.Including && a.PropertyType.IsValueType==false && a.PropertyType.Name.IsIgnoreCaseMatch("String")==false) ;
            //linq pad debugging helper
    		//var propertyTypesSerializing= allProperties.Where (p => p.Including).Select (p => p.PropertyType).Distinct().OrderBy (p => p.Name).Dump();
    		if(warnProperties.Any())
    		{
                //LinqPad helper
    			//Util.Highlight(warnProperties.ToArray()).Dump("warning flag raised, aborting");
    			throw new ArgumentOutOfRangeException();
    		}
        
        	properties = properties.Where(p =>includeProperty(p.PropertyType)).ToList();
        	return properties;
        }
    }
