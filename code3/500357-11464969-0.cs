    public interface IPropertyGroupCollection
    {
        IEnumerable<IPropertyGroup> _Propertygroups { get;}
    }
    
    public interface IPropertyGroup
    {
        IEnumerable<IProperty> _conditions { get; }
    }
    
    public interface IProperty
    {
    }
    
    public interface IProperty<T, U, V> : IProperty
    {
        T _p1 { get; }
        U _p2 { get; }
        V _p3 { get; }
    }
    
    public class Property<T, U, V> : IProperty<T, U, V>
    {
        //Some Implementation
    }
