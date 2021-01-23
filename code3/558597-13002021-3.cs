    class Foo
    {
        private string name;  //don't use public for instance members
    
        public Foo(string name){
            this.name = name;
        }
    
        public string getName
        {
          get{
            return this.name;
          }
        }
    }
    
    Foo test = new Foo("test");
    
    Console.WriteLine(test.getName);
