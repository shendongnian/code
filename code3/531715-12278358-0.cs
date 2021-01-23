    public abstract class Condition
    {
       public abstract bool ConditionMet(params[] parameters); 
    }
    
    public class DateTimeCondition : Condition
    {
        public override bool ConditionMet(params[] parameters)
        {
           // check condition against DateTime values available inside parameters
        }
    }
    
    public class MoreThen10: Condition
    {
        public override bool ConditionMet(params[] parameters)
        {
           // check condition against numeric values more then 10
        }
    }
    
    ... // and so on 
