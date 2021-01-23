     public class Class1
     {
       private class Class2
        {
          public Class2() // constructor of Class2
          { 
          }
          public void Add(int a, int b) // Method in Class2
          {
            this.Add(a, b);
          }
        }
    public Class1() // constructor of Class1
    { 
        Class2 cs2 = new Class2();
        cs2.Add(4,5);
    }
   }
