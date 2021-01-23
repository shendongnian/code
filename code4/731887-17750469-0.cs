    public class LittleClass {
      public int LittleId {get; set;}
      public string LittleDescription {get; set;}
      public decimal ValueOne {get; set;}
      public decimal ValueTwo {get; set;}
      public decimal LittleTotalValue 
      {
        get
        {
           return this.ValueOne + this.ValueTwo;
        }
      }
    }
