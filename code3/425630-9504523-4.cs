    class Evaluator {
     public void Evaluate(IEnumerable<ITimedValue> values) {
     	foreach(var v in values)
    	{
    		Eval((dynamic)(v));
    	}
     }
     
     private void Eval(DateTimeValue d) {
     	Console.WriteLine(d.Value.ToString() + " is a datetime");
     }
     
     private void Eval(NumericValue f) {
     	Console.WriteLine(f.Value.ToString() + " is a float");
     }
     
    }
