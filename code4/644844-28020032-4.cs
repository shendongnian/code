    class Program
    {
        internal class StateKeys
        {
            public const string Off = "Off";
            public const string Idle = "Idle";
        }
        static void Main(string[] args)
        {
            CarStateManager stateManager = new CarStateManager();
            stateManager.AddState(StateKeys.Off, new OffState());
            stateManager.AddState(StateKeys.Idle, new IdleState());
            stateManager.ChangeState(StateKeys.Off);
            Console.WriteLine(stateManager.CurrentState.Message);
            stateManager.ChangeState(StateKeys.Idle);
            Console.WriteLine(stateManager.CurrentState.Message);
            Console.ReadLine();
        }
    }
