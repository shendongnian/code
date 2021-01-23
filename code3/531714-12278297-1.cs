    public class SimpleConditionParameters : IConditionParameters
    {
       public int XValue { get; set; }
    }
    public class ComplexConditionParameters : IConditionParameters
    {
       public int XValue { get; set; }
    
       public int YValue { get; set; }
    
       public bool SomeFlag { get; set; }
    }
    
    var conditions = new List<Predicate<IConditionParameters>>();
    Predicate<SimpleConditionParameters> simpleCondition = (p) => 
    {
       return p.XValue > 0;
    };
    
    Predicate<ComplexConditionParameters> complexCondition = (p) => 
    {
       return p.SomeFlag && p.XValue > 0 && p.YValue < 0;
    };
    conditions.Add(simpleCondition);
    conditions.Add(complexCondition);
