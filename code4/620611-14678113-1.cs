    public class Foo
    {
        //Import using the contract name.
        [Import("Foo1", typeof(IModel))]
        public IModel Model1 { get; set; }
        //Import using the actual type.
        [Import(typeof(Foo2))]
        public IModel Model2 { get; set; }
        //Import the same model but with contract name instead of type. 
        //This is possible because there are two different exports.
        [Import("Foo2")]
        public IModel Model3 { get; set; }
    }    
