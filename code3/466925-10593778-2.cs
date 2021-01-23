    class Sales  
    {  
       public static string Amount = "10" //You don't require get/set here  
    } 
    class Test    
    { 
        public Test()
        {
            Sales.Amount = "10";    
        }
    }    
