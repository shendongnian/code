    public class MyContractResolver:DefaultContractResolver
    {
    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
    {
        var property = base.CreateProperty(member,memberSerialization);
        
		var propertyType = property.PropertyType;
		if(propertyType == typeof(int) 
			|| propertyType == typeof(string)){
			property.ShouldSerialize = instance => true;
		}
		else
		{
			property.ShouldSerialize = instance => false;
		}
        return property;
    }
    }
