    public abstract class TestAbstract
    {
        public void MainFunc() 
        { 
            //common code
            Func1();
            Func2(); 
        }
    
        public abstract void Func1();
        public abstract void Func2();
    }
    public class ClassA : TestAbstract 
    {
        public void Func1() 
        { //... logic for ClassA
        }
        public void Func2() 
        { //... logic for ClassA 
        }
    }
