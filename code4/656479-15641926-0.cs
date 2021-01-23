    public abstract class DynamicClass
    {
         public virtual Type ObjectType { get; set; }
         public virtual List<string> PropertyNameList { get; set; }
         public virtual List<Type> PropertyTypeList { get; set; }
    }
