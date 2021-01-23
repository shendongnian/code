    public abstract class IntCalculator
    {
       protected List<int> values = new List<int>();
       public void AddValue(int value) { values.Add(value); }
       public abstract int Calculate(); 
    
    }
    
    public class Adder : IntCalculator
    {
       public override int Calculate()
       {
            return  values.Sum(x=>x);
       }
    }
    
    
    public class Multiplier : IntCalculator
    {
       public override int Calculate()
       {
            return  //multiply all values;
       }
    }
