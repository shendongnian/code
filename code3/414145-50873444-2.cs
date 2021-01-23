    public class MagicDecorator : IMagic
    {
       private IMagic _magic;
       public MagicDecorator(IMagic magic)
       {
           _magic = magic;
       }
       
       private void BaseMethod()
       {
           // do something important
       }
        public void Method1()
        {
             BaseMethod();
             _magic.Method1();
        }
    
        
        public void Method2()
        {
            BaseMethod();
            _magic.Method2();
        }
    }
