    class Program
    {
            public void DoAction()
            {
                Console.WriteLine("actioned");
            }
            public delegate void ActionDoer();
            public void Do()
            {
                Console.ReadLine();
            }
            public static void Express(Expression<Func<Program, ActionDoer>> expression)
            {
                Program program = new Program();
                Func<Program, ActionDoer> function = expression.Compile();
                function(program).Invoke();
            }
            [STAThread]
            public static void Main()
            {
                Express(program => program.DoAction);
                Console.ReadLine();
            }
    }
