    public class CustomAttribute: System.Attribute
    {
        public CustomAttribute()
        {
        }
    }
    TypeBuilder typeBuilder = module.DefineType(...)
....
    typeBuilder.SetCustomAttribute(new CustomAttributeBuilder(
        typeof(CustomAttribute).GetConstructor(Type.EmptyTypes), 
        Type.EmptyTypes, 
        new FieldInfo[0], 
        new object[0]));
