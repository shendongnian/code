    class Program
    {
        internal class StateKeys
        {
            public const string Off = "Off";
            public const string Idle = "Idle";
        }
        static void Main(string[] args)
        {
            // Instantiate the state manager
            CarStateManager stateManager = new CarStateManager();
            
            // Add the states
            stateManager.AddState(StateKeys.Off, new OffState());
            stateManager.AddState(StateKeys.Idle, new IdleState());
            
            // Change the state and display the message
            stateManager.ChangeState(StateKeys.Off);
            Console.WriteLine(stateManager.CurrentState.Message);
            
            // Change the state and display the message
            stateManager.ChangeState(StateKeys.Idle);
            Console.WriteLine(stateManager.CurrentState.Message);
            Console.ReadLine();
        }
    }
