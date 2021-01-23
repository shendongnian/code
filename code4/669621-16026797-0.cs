    public class Rain
    {
        public decimal rainValueInCM;
        public decimal rainValueInMM;
       // public Dictionary<decimal, Temperature> Temperature = new Dictionary<decimal, Temperature>();
    
        public Rain(decimal cm)
        {
            rainValueInCM = cm;
        }
    
        public  decimal ConvertToCM(decimal mm)
        {   
            rainValueInCM = (mm / 10);
            return rainValueInCM;  
        }
    }
    public class AnotherClass
    {
         public void SomeMethod() 
         {
             Rain myRain = new Rain(5); // create the instance
             // use the value
             decimal theValue = myRain.rainValueInCM;
         }
    }
