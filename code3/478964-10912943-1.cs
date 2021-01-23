        public class ActionTest
    {
        public void DoAction(Action action)
        {
            action();
        }
        public void DoExpressionAction(Expression<Action> action)
        {
            var method2Info = ((MethodCallExpression)action.Body).Method;
            // a little recursion needed here
            var method1Info = ((MethodCallExpression)((MethodCallExpression)action.Body).Object).Method;
            var myattributes2 = method2Info.GetCustomAttributes(typeof(MyAttribute), true);
            var myattributes1 = method1Info.GetCustomAttributes(typeof(MyAttribute), true);
            action.Compile().Invoke();
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class MyAttribute : Attribute
    {
    }
    public class MethodTest
    {
        [MyAttribute]
        public MethodTest Method1()
        {
            Console.WriteLine("Action");
            return this;
        }
        [MyAttribute]
        public MethodTest Method2()
        {
            Console.WriteLine("ExpressionAction");
            return this;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ActionTest target = new ActionTest();
            MethodTest instance = new MethodTest();
            target.DoExpressionAction(() => instance.Method1().Method2() );
            Console.ReadLine();
        }
        static void Method1()
        {
            Console.WriteLine("Action");
        }
        static void Method2()
        {
            Console.WriteLine("ExpressionAction");
        }
    }
