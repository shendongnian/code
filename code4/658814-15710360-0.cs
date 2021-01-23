    public class Foo
    {
        public int ID { get; set; }
        public String Name { get; set; }
    public Foo()
    {
    }
    public Foo( int id )
    {
    // Win()
    ID = id;
    // Win()
    }
    
    Public Foo( string name )
    {
    // Win()
    Name = name;
    // Win()
    }
    
    public Foo( int id, string name )
    {
    // Win()
    ID = id;
    Name = name;
    // Win()
    }
    
        public void Win()
        {
            //Do Stuff that would go into the constructor
            //if I wanted to use optional parameters
            //but I don't
        }
    }
