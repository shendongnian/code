    public interface IPropertyProvider<T>
    {
        T Prop2 { get; set; }
    }
    
    public class ObjectService<T, TProp> where T : IPropertyProvider<TProp>
    {
        public void SaveProperty(T o, TProp i)
        {
            o.Prop2 = i;
        }
    }
    
    public class Object1 : IPropertyProvider<string>
    {
        public string Prop1 { get; set; }
        public string Prop2 { get; set; }
    }
    
    public class Object2 : IPropertyProvider<int>
    {
        public string Prop1 { get; set; }
        public int Prop2 { get; set; }
        public int Prop3 { get; set; }
    }
	
    public class Object1Service : ObjectService<Object1, string>
    {
    }
    
    public class Object2Service : ObjectService<Object2, int>
    {
    }
