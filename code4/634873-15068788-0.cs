    class Program
    {
        int x = 20;
        public void pro1()
        {
           Console.WriteLine( this.x);
            
            Console.WriteLine("pr1 call");
            
            
        }
    }
    static class porgram2
    {
      static  int x = 10;
        public static void pro2()
        {
        Console.WriteLine(    porgram2.x); //Not need a object 
            Console.WriteLine("pro2 call");
                                         // This keyword is not allowed.  
        
        }
        static void Main(string[] args)
        {
            porgram2.pro2(); // no need a object created. 
            Program pr = new  Program();//Must be a created object. 
            pr.pro1();
            Program pr2 = new Program(); // i have many time of create a object.
            pr2.pro1();
  
