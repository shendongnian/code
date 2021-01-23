    public class IdContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            if (propertyName == "Id") return "_id";
            return base.ResolvePropertyName(propertyName);
        }
    }
