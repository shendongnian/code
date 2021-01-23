    public class A
    {
        //Don't make this method virtual because you don't actually want inheritors 
        //to be able to override this functionality.  Instead, you want inheritors
        //to be able to append to this functionality.
        public void MethodOne()
        {
            Console.WriteLine( "A" ); 
            MethodToBeOverriddenOne();
        }
        //Expose a place where inheritors can add extra functionality
        protected virtual void MethodToBeOverriddenOne() { }      
    }
    
    public class B : A
    {
        //Seal the method because you don't actually want inheritors 
        //to be able to override this functionality.  Instead, you want inheritors
        //to be able to append to this functionality.
        protected sealed override void MethodToBeOverriddenOne()
        {
            Console.WriteLine("B");
            MethodToBeOverriddenTwo();
        }
        //Expose a place where inheritors can add extra functionality
        protected virtual void MethodToBeOverriddenTwo() { }  
    }
    
    public class C : B
    {
        protected sealed override void MethodToBeOverriddenTwo()
        {
            Console.WriteLine("C");
        }
    }
