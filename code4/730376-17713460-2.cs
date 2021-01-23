    // Example of ref:
    // p does not copy x's reference value of the object
    // p refers to the same memory location as x's 
    // Changes made to p also do to x (e.g. nulling p will also null x)
    class Ref_Example
    {
       static void Foo(ref int p) { p = 8};
       static void Main() { 
          int x = 5; Foo(ref x);
          Console.WriteLine(x);    // output: 8 
       }
    }
    
    // Example of out:
    // out = ref, except it needs not be assigned before calling method
    // Using out allows you to return multiple values from a function  
    Class Out_Example
    {
       static void Find_Synonyms(
              string vocab, out string synonymA, out string synonymB)
       { // Lookup the synonyms of the word "rich" };
   
       static void Main()
       {
          string a, b;
          Find_Synonyms("rich", a, b);
          Console.WriteLine(a);   // abundant
          Console.WriteLine(b);   // affluent
    }
