    internal class BaseClass
    {
        public virtual string str()
        {
            return "Hello my name is" ;
        }
    }
    class ChildClass : BaseClass
    {
        public override string str(){
            return base.str() + "Sam";
        }
    }
   
