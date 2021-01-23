    public class LegVMFactory: ILegVMFactory{
      private readonly ILeg leg;
      public LegFactory(ILeg _leg){
        if(_leg == null) throw new Exception(""); //throw any exception you feel proper here
        this.leg = _leg;
      }
      public ILegViewModel Create(){
        if(leg is Leg){
          return new LegViewModel();
        }
        else if(leg is LegV1){
          return new LegV1ViewModel();
        }
        else if(leg is LegV2){
          return new LegV2ViewModel();
        }
        // and so on
      }
    }
