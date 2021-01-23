        public class CalculatorConfig 
        { 
          public double param1; 
          public double param2; 
          ... 
          internal void Check()
          {
               if(param1 == 0.0)
                   throw new ArgumentException("Configuration error: param1 is not valid!");
               if(param2 == 0.0)
                   throw new ArgumentException("Configuration error: param2 is not valid!");
               .... // other internal checks
          }
        } 
        public class Calculator 
        { 
            private CalculatorConfig _config; 
            public Calculator(CalculatorConfig config) 
            { 
                _config = config; 
            } 
     
            public Result Calculate(object obj)
            {
                // Throw ArgumentException if the configuration is not valid
                // Will be responsability of our caller to catch the exception
                _config.Check();
            
                // Do your calcs
                .....
            } 
        } 
