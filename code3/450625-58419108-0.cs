    public class FlatLoopInjectionNullable : Omu.ValueInjecter.Injections.FlatLoopInjection
    {
        protected override bool Match(string propName, PropertyInfo unflatProp, PropertyInfo targetFlatProp)
        {
            var snt = Nullable.GetUnderlyingType(unflatProp.PropertyType);
            var tnt = Nullable.GetUnderlyingType(targetFlatProp.PropertyType);
    
            return propName == unflatProp.Name
                && unflatProp.GetGetMethod() != null
                && (unflatProp.PropertyType == targetFlatProp.PropertyType
                    || unflatProp.PropertyType == tnt
                    || targetFlatProp.PropertyType == snt
                    || snt == tnt);
        }
    }
