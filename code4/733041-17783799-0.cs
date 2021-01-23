    using System;
    
    public class MainClass { public void Main() { print "hello world"; } }
    public class SubClassOne : MainClass { }
    public class SubClassTwo : MainClass { }
    
    public class Storer
    {
        public void Main() {
         object[] objects = new object[2];
         objects[0] = new SubClassOne();
         objects[1] = new SubClassTwo();
         for(i=0;i<2;i++)
         {
            var myMainClass = objects[i] as MainClass;
            if (myMainClass != null)
            {
                myMainClass.Main();
            }
         }
     }
    }
