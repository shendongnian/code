    class Foo
    {
       private static int f;
    
       private class Bar  // nested class
       {
           void B() 
           { 
              int b = f;  // access to private member of containing class
           }
       }
    }
