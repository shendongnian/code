    // Example of ref:
    // p DOES NOT copy x's reference value of the object
    // p is x (or refer to the same memory as x)
    class Ref_Example
    {
       static void Foo(ref int p) { p = 8};
       static void Main() { 
          int x = 5; Foo(ref x);
          Console.WriteLine(x);    // output: 8 
       }
    }
    
    // Example of out:
    // out = ref, except variables need not be assigned before method is called
    // You use out when you have to return multiple values from a function  
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
