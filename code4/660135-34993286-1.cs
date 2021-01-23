    public class IgnoreErrorPropertiesResolver : DefaultContractResolver
    {
	    protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
	    {
		    JsonProperty property = base.CreateProperty(member, memberSerialization);
		    if ({"InputStream",
			    "Filter",
			    "Length",
			    "Position",
			    "ReadTimeout",
			    "WriteTimeout",
			    "LastActivityDate",
			    "LastUpdatedDate",
			    "Session"
		    }.Contains(property.PropertyName)) {
			    property.Ignored = true;
		    }
		    return property;
	    }
    }
