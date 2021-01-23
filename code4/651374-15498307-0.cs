    public interface IHasProperty {
       ValueClass PropertyAsValueClass { get;set; }
    }
    public class TestClass<T> : IHasProperty where T : ValueClass
    {
       public T Property {get;set;}
       public ValueClass PropertyAsValueClass {
         get { return this.Property; }
         set { this.Property = value as T; }
       }
    }
    
    public class TestClass1 : TestClass<ValueClass>
    {
    }
    
    public class TestClass2 : TestClass<ValueClass2>
    {
    }
    
    public class ValueClass
    {
        public int Id { get; set; }
    }
    
    public class ValueClass2 : ValueClass
    {
    }
