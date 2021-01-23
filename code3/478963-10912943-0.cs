        public class ActionTest
        {
            public void DoAction(Action action)
            {
                action();
            }
    
            public void DoExpressionAction(Expression<Action> action)
            {
                action.Compile().Invoke();
            }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                ActionTest target = new ActionTest();
    
                target.DoAction(() => Console.WriteLine("Action"));
    
                target.DoExpressionAction(() => Console.WriteLine("ExpressionAction"));
    
                Console.ReadLine();
            }
        }
