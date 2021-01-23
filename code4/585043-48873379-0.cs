    public class Data 
    {
       public string _foo;
       public int _bar;
    }
    
    public class Mutable 
    {
       private Data _data = new Data();
       public Mutable() {}
       
       public string Foo { get => _data._foo; set => _data._foo = value; }
       public int Bar { get => _data._bar; set => _data._bar = value; }
  
       public Frozen Freeze() 
       { 
          var f = new Frozen(_data);
          _data = null;
          return f;
       }
    }
    public class Frozen 
    {
       private Data _data;
       public Frozen(Data data) => _data = data;              
       public string Foo => _data._foo;  
       public int Bar => _data._bar;
  
       public Mutable Thaw() 
       { 
          var m = new Mutable(_data);
          _data = null;
          return m;
       }
    }
 
