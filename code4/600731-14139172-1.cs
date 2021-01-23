    using System;
    
    public interface A
    {
        void DoSmth();
    }
    
    public class B
    {
        public void OpA() { }
        public void OpB() { }
    }
    
    public class ClassC : B, A
    {
        public void DoSmth(){}
    }
