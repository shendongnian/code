        void DoSomething(Field field)
        {
            var decimalField = field as DecimalField;
    
            //Do something with the decimal field instance
            if(decimalField  !=null)
             {
               Console.WriteLine("Decimal Field Property {0}",decimalField .DecimalFieldProperty );
              return;
    
            }
    
            //Cast the field as a account field instance
          var accountField = field as AccountField;
           if(accountField !=null)
           {
             Console.WriteLine("Balance {0}", accountField.Balance );
    
            return;
          }
    
          //Do something else with the normal field
        Console.WriteLine("Normal Field");
         
        }
