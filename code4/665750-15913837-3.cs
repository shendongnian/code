    public static class SimpleStateMachine
    {
        public static void StateA(Context context)
        {
            context.State = StateB;
        }
        public static void StateB(Context context)
        {
            Console.Write("Input state: ");
            var input = Console.ReadLine();
            context.State = input == "e" ? (Action<Context>)null : StateA;
        }
    }
