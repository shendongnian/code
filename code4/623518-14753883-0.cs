     public abstract class AbstractClass
        {
            public abstract void AbstractMethod();
            public void CommonCode()
            {
                //do something
            }
        }
    
        public class ChildClass : AbstractClass
        {
            public override void AbstractMethod()
            {
                //automatically call CommonCode in base class
                //do something
                base.CommonCode();
            }
        }
