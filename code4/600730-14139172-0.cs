    using System;
    
    public interface intA {
        void DoSmth();
    }
    
    public class clsB {
        public void OpA();
        public void OpB();
    }
    
    public class ClassC : clsB, intA
    {
    	public ClassC()
    	{
    	}
          public void DoSmth{}
    }
