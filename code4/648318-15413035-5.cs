    public class A
    {
       public B B { get; set; }
    
       public A()
       {
          B=new B();
       }
    }
    
    public class B
    {
       private static int counter = 0;
       public string strDes { get; set; }
    
       public B()
       {
          strDes = "foo"+counter;
          counter++;
       }
    }
