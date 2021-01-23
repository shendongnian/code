    namespace RuleConsole
    {
       class Program
       {
          static void Main(string[] args)
          {
             var context = new RulesContext();
    
             var objA = new A();
             var objB = new B();
    
             context.AddRule<A>(new Rule<A>(objA));
             context.AddRule<B>(new Rule<B>(objB));
    
             Console.WriteLine(context.CanIRead<A>(objA));
             Console.WriteLine(context.CanIRead<B>(objB));
    
             Console.ReadKey();
          }
       }
    
       public interface IRule { }
       public interface IRule<T> : IRule { }
    
       public class Rule<T> : IRule<T> 
       {
          T _entity;
          public Rule(T entity)
          {
             _entity = entity;
          }
       }
    
       public class A { }
       public class B { }
    
       public class RulesContext
       {
          Dictionary<Type, IRule> _ruleDict= new Dictionary<Type, IRule>();
    
          public void AddRule<TEntity>(Rule<TEntity> rule)
          {
             _ruleDict.Add(typeof(TEntity), rule);
          }
          
          public bool CanIRead<TEntity>(TEntity entity)
          {
             var rule = (IRule<TEntity>)_ruleDict[typeof(TEntity)];
             
             //CanIRead implementation here
    
             return rule != null;
          }
       }
    }
