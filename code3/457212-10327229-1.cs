    public interface IInvocable
    {
       void PreInvoke();
       void PostInvoke();
    }
    public class MyFooExecutable : IInvocable
    {
        public void PreInvoke() { /* something */ }
        public void PostInvoke() { /* something */ }
    }
    public static class InvocableExtensions
    {
        public static void Execute<T>(this IInvocable self, Action<T> action, T value)
        {
            self.PreInvoke();
            action(value);
            self.PostInvoke();
        }
    }
