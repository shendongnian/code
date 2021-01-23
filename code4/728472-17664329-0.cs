    public class Derived : Base{
    
    
    public override double Value{
       get { return _coefficient; }
       set { 
         if(Coefficient == 0){
           base.Value = value;
         }else{
           base.Value = value / Coefficient; 
         }
    }
    private double _coefficient;
    public double Coefficient{
       get { return _coefficient; }
       set { 
         if(Coefficient == 0){
             temp = base.Value;
             _coefficient = value;
             Value = temp; 
         }else{
           _coefficient = value;
         }
    }
    
  }
