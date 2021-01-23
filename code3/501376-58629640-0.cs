[DataContract]
public class SerializableDynamicObject : IDynamicMetaObjectProvider
{
    [DataMember]
    private IDictionary<string,object> dynamicProperties = new Dictionary<string,object>();
     
    #region IDynamicMetaObjectProvider implementation
    public DynamicMetaObject GetMetaObject (Expression expression)
    {
        return new SerializableDynamicMetaObject(expression, 
            BindingRestrictions.GetInstanceRestriction(expression, this), this);
    }
    #endregion
     
    #region Helper methods for dynamic meta object support
    internal object setValue(string name, object value) 
    {
        dynamicProperties.Add(name, value);
        return value;
    }
     
    internal object getValue(string name) 
    {
        object value;
        if(!dynamicProperties.TryGetValue(name, out value)) {
            value = null;
        }
        return value;
    }
     
    internal IEnumerable<string> getDynamicMemberNames() 
    {
        return dynamicProperties.Keys;
    }
    #endregion
}
 
 
public class SerializableDynamicMetaObject : DynamicMetaObject
{
    Type objType;
     
    public SerializableDynamicMetaObject(Expression expression, BindingRestrictions restrictions, object value) 
        : base(expression, restrictions, value) 
    {
        objType = value.GetType();
    }
     
    public override DynamicMetaObject BindGetMember (GetMemberBinder binder)
    {
        var self = this.Expression;
        var dynObj = (SerializableDynamicObject)this.Value;
        var keyExpr = Expression.Constant(binder.Name);
        var getMethod = objType.GetMethod("getValue", BindingFlags.NonPublic | BindingFlags.Instance);
        var target = Expression.Call(Expression.Convert(self, objType),
                                     getMethod,
                                     keyExpr);
        return new DynamicMetaObject(target,
            BindingRestrictions.GetTypeRestriction(self, objType));
    }
     
    public override DynamicMetaObject BindSetMember (SetMemberBinder binder, DynamicMetaObject value)
    {
        var self = this.Expression;
        var keyExpr = Expression.Constant(binder.Name); 
        var valueExpr = Expression.Convert(value.Expression, typeof(object));
        var setMethod = objType.GetMethod("setValue", BindingFlags.NonPublic | BindingFlags.Instance);
        var target = Expression.Call(Expression.Convert(self, objType),
        setMethod, 
        keyExpr, 
        valueExpr);
        return new DynamicMetaObject(target,
            BindingRestrictions.GetTypeRestriction(self, objType));
    }
     
    public override IEnumerable<string> GetDynamicMemberNames ()
    {
        var dynObj = (SerializableDynamicObject)this.Value;
        return dynObj.getDynamicMemberNames();
    }
}
A simple way to use it:
dynamic d = new SerializableDynamicObject();
d.Name = “SomeData”;
d.Address = new SerializableDynamicObject();
d.Address.Line1 = “123 Spring St.”;
dynamic a = new SerializableDynamicObject();
a.Items = new List(new object[] { d, d });
return a;
However keep in mind that WCF requires knowledge of data types, since it most most basic data types like `string`, `int` etc it isn't a problem. But if you're using a custom data type in your dynamic object, you must define in using the `[KnownType(typeof(XXX))]` directive.
This applies to `enums`, `List<>` and any other custom classes.
For example:
[KnownType(typeof(MyCustomEnum))]
[KnownType(typeof(List<object>))]
[DataContract]
public class SerializableDynamicObject : IDynamicMetaObjectProvider
...
