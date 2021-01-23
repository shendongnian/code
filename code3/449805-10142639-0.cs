    using System;
    public class MyBase
    {
       int num;
       
       public MyBase(int i )
       {
          num = i;
          Console.WriteLine("in MyBase(int i)");
       }
    
       public int GetNum()
       {
          return num;
       }
    }
    
    public class MyDerived: MyBase
    {
           
        // This constructor will call MyBase.MyBase(int i)
        ***//You are missing this.***
       public MyDerived(int i) : base(i)
       {
       }
    
    }
