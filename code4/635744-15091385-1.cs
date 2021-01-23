    class Program {
         public static void Main(string[] args) {
             SomeClass someInstance = new SomeClass();
             IContract<SomeContractClass> first= someInstance;
             IContract second = someInstance;
 
             someInstance.Definition(new SomeContractClass()); 
             // prints out "Processing a SomeContractClass instance"
             first.Definition(new SomeContractClass());
             // prints out "Processing a SomeContractClass instance"
             second.Definition(new SomeContractClass());
             // prints out "Processing a SomeContractClass instance"
             second.Definition( "something else" );
             // prints "Processing something other 
             // than a SomeContractClass instance: An instance of String"
             second.Definition( 123 );
             // prints "Processing something other
             // than a SomeContractClass instance: An instance of Int32"
             first.Definition( true );
             // doesn't compile saying that bool can't be converted to SomeContractClass
         }
    }
