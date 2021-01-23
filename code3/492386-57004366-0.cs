    public class TitleCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            //Change the incoming property name into Title case
            var name = string.Concat(propertyName[0].ToString().ToUpper(), propertyName.Substring(1).ToLower());
            return base.ResolvePropertyName(name);
        }
    }
    public class LowerCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            //Change the incoming property name into Lower case
            return base.ResolvePropertyName(propertyName.ToLower());
        }
    }
    public class UpperCaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            //Change the incoming property name into Upper case
            return base.ResolvePropertyName(propertyName.ToUpper());
        }
    }
