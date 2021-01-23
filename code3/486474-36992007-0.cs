    public interface IActionLoggerObject
    {
        string GetForLogging();
    }
    public class ActionLoggerObjectInt : IActionLoggerObject
    {
        public string GetForLogging()
        {
            return "s";
        }
    }
    public static class ExtensionMethods
    {
        public static IActionLoggerObject AsActionLoggerObject(this int i)
        {
            return new ActionLoggerObjectInt();
        }
    }
