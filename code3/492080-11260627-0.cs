    public class PcTablet :ISmartPhone, ILaptop
    {
         private SmartPhone _smartphone;
         private Laptop _laptop;
         public void ISmartPhone.Call()
         {
             _smartPhone.Call();
             // OR IMPLEMENT THE RIGHT BEHAVIOR 
             //INSTEAD OF CALLING _smartPhone.Call()
         }
    }
