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
    Dictionary<int, ICallable> Actions = new Dictionary<int, ICallable>
    {
        { 1, new Login() }
        { 2, new Logout() }
    }
