    public class DataRepository {
          
          LoadSessionTradingPrtNrVM TransformToVM(LoadSession inputA, TradingPartner inputB){
                LoadSessionTradingPrtNrVM newOBJ = new LoadSessioNTradingPrtNrVM();
                newOBJ.LoadSessionId = ipnutA.LoadSessionID;
                newOBJ.Import = inputA.Import
                //Here is the property from your Transform object
                newOBJ.Description = inputB.Description
                //...  Continue to transform one object into the other... 
                //You could add as many members from as many different objects as you want into 
                //Your view model following that pattern. 
          }
    }
