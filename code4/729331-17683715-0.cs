    public class Car : IRadioSite
    {
         Radio _radio;
         public Car() 
         {
             _radio = new Radio(this);
         }
         public Radio { get { return _radio; } }
    }
