    void Main()
    {
        var t1 = new Type1(); // ie Sql Reader
        var t2 = new Type2(); // ie DataRow
        
        DoSomething(new Type1IndexAdapter(t1));
        DoSomething(new Type2IndexAdapter(t2));
    }
    
    public void DoSomething(ICanIndex indexer)
    {
        var r = indexer["test"];
    }
    
    public interface ICanIndex
    {
        string this[string index]{get;}
    }
    
    public class Type1IndexAdapter : ICanIndex
    {
        public Type1 value;
        public Type1IndexAdapter(Type1 val)
        {
            this.value = val;
        }
        public string this[string index]
        {
            get
            {
                return this.value[index];
            }
        }
    }
    
    public class Type2IndexAdapter : ICanIndex
    {
        public Type2 value;
        public Type2IndexAdapter(Type2 val)
        {
            this.value = val;
        }
        public string this[string index]
        {
            get
            {
                return this.value[index];
            }
        }
    }
    
    public class Type1 // ie SqlDataReader 
    {
        public string this[string index]
        {
            get
            {
                Console.WriteLine("Type 1 indexer called: " + index);
                return null;
            }
        }
    }
    
    
    public class Type2 // ie DataRow 
    {
        public string this[string index]
        {
            get
            {
                Console.WriteLine("Type 2 indexer called: " + index);
                return null;
            }
        }
    }
