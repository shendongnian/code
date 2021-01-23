namespace ExceptionExample
{
    public static class ExceptionExtensions
    {
        public static void SetMessage(this Exception exception, string message)
        {
            if (exception == null)
                throw new ArgumentNullException(nameof(exception));
    
            var type = typeof(Exception);
            var flags = BindingFlags.Instance | BindingFlags.NonPublic;
            var fieldInfo = type.GetField("_message", flags);
            fieldInfo.SetValue(exception, message);
        }
    }
}
And then use it...
...
using static ExceptionExample.ExceptionExtensions;
public class SomeClass
{
    public void SomeMethod()
    {
        var reader = AnotherClass.GetReader();
        try
        {
            reader.Read();
        }
        catch (Exception ex)
        {
            var connection = reader?.Connection;
            ex.SetMessage($"The exception message was replaced.\n\nOriginal message: {ex.Message}\n\nDatabase: {connection?.Database}");
            throw; // you will not lose the stack trace
        }
    }
}
You have to keep in mind that if you use "throw ex;" **the stack tracking will be lost**.
To avoid this **you must use "throw;" without the exception**.
