        var list = from item in ObjectContext.Plants
        where item.ID == ID
        select new Model()
           {
               ID = item.ID,
               Name = item.Name,
               NumericValue = item.numericValue, 
               UpperHighLimit = item.UpperHighLimit
               LowerHighLimit = item.LowerHighLimit
               UpperLowLimit =  item.UpperLowLimit
               LowerLowLimit = item.LowerLowLimit
           };
         public class Model()
         {
               public int UpperHighLimit {get;set;} //And all the others
               public Model()
               {
                  //Do Calculations here with your 5 properties
               }
         }
