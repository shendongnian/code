    public class TaxiStation
    {
      ..... 
        public virtual string TaxiInformation(int i){
           ....
        }
       
    }
    
    
    public class Taxi : TaxiStation 
    {
        public override string TaxiInformation(int i){
           ....
        }
    }
