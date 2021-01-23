    using System;
    public abstract class MainClass { public abstract void Main(); }
    
    public class SubClassOne : MainClass { 
        public override void Main() { print "SubClassOne, hello world"; } 
    }
    public class SubClassTwo : MainClass { 
        public override void Main() { print "SubClassTwo, hello world"; }
    }
    public class Storer
    {
        public void Main() {
            MainClass[] objects = new MainClass[2];
            objects[0] = new SubClassOne();
            objects[1] = new SubClassTwo();
            foreach(MainClass mc in objects)
            {
                mc.Main();
            }
        }
    }  
