        public class DynamicContractResolver : DefaultContractResolver
    	{
    		protected override JsonProperty CreateProperty(System.Reflection.MemberInfo member, MemberSerialization memberSerialization)
    		{
    			var r = base.CreateProperty(member, memberSerialization);
    			r.Ignored = false;
    			return r;
    		}
    	}
