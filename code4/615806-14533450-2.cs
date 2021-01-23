    public interface MyInterface
    {
        void SomeCommonMethod(object whatever);
    
        void SomeSpecialisedMethod(int someOtherParameter);
    }
    
    public abstract class MyBaseClass : MyInterface
    {
        public void SomeCommonMethod(object whatever)
        {
            //do some stuff
        }
    
        public abstract void SomeSpecialisedMethod(int someOtherParameter);
    }
    
    public class SomeSpecialisedClass : MyBaseClass
    {
        public override void SomeSpecialisedMethod(int someOtherParameter)
        {
            //do stuff that can't be done in the base class
        }
    }
