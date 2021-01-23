    public interface ITimedValueEvaluator
    {
       void Evaluate(ITimedValue value);
    }
    
    public interface ITimedValueEvaluator<T>:ITimedValueEvaluator
    {
       void Evaluate(ITimedValue<T> value);
    }
    
    //each implementation is responsible for implementing both interfaces' methods,
    //much like implementing IEnumerable<> requires implementing IEnumerable
    class NumericEvaluator: ITimedValueEvaluator<int> ...
    
    class DateTimeEvaluator: ITimedValueEvaluator<DateTime> ...
    
    public class Evaluator
    {
       private Dictionary<Type, ITimedValueEvaluator> Implementations;
       
       public Evaluator()
       {
          //find all implementations of ITimedValueEvaluator, instantiate one of each
          //and store in a Dictionary
          Implementations = (from t in Assembly.GetCurrentAssembly().GetTypes()
          where t.IsAssignableFrom(typeof(ITimedValueEvaluator<>)
          and !t.IsInterface
          select new KeyValuePair<Type, ITimedValueEvaluator>(t.GetGenericArguments()[0], (ITimedValueEvaluator)Activator.CreateInstance(t)))
          .ToDictionary(kvp=>kvp.Key, kvp=>kvp.Value);      
       }
    
       public void Evaluate(ITimedValue value)
       {
          //find the ITimedValue's true type's GTA, and look up the implementation
          var genType = value.GetType().GetGenericArguments()[0];
    
          //Since we're passing a reference to the base ITimedValue interface,
          //we will call the Evaluate overload from the base ITimedValueEvaluator interface,
          //and each implementation should cast value to the correct generic type.
          Implementations[genType].Evaluate(value);
       }   
    
       public void Evaluate(IEnumerable<ITimedValue> values)
       {
          foreach(var value in values) Evaluate(value);
       }
    }
