          // writer app
          public class LogWritter
          {   
              using (new SingleGlobalInstance(-1))
              {   
                  xmlDoc.Load(_logFilePath);
                  //Write Log Code
                  xmlDoc.Save(_logFilePath);
              }
          }
         // reader app
         public class LogReader
         { 
              using (new SingleGlobalInstance(-1))
              {   
                  Load(logFilePath);
              }
              //Reader code    
         }
 
