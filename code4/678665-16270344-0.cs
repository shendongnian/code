    public class JewelUI{
      public explicit operator JewelUI(Jewel jewel){
        JewelUI jewelUI = new JewelUI();
        // assign birthdate and name
        jewelUI.BirthStone = GetBirthStone(jewel.BirthDate.Month);
      }
    
      public string BirthStone{get;set;};
    
      public string GetBirthStone(int month){
        if(month == 1) return "Diamond";
        //etc etc
      }
    }
