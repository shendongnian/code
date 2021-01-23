    public interface ICallable
    {
        void Execute();
    }
    public class Login : ICallable
    {
        // Implement ICallable.Execute method
        public void Execute()
        {
            // Do something related to Login.
        }
    }
    public class Logout : ICallable
    {
        // Implement ICallable.Execute method
        public void Execute()
        {
            // Do something related to Logout
        }
    }
    public class AD
    {
        Dictionary<string, ICallable> Actions = new Dictionary<int, ICallable>
        {
            { "Login", new Login() }
            { "Logout", new Logout() }
        }
        public void Do(string command)
        {
            Actions[command].Execute();
        }
    }
