    public class Factory<T>
    {
        public static T getInstance()
        {
            return getInstance(typeof(T), null);
        }
        public static T getInstance(object[] initializationParameters)
        {
            return (T)Activator.CreateInstance(typeof(T), initializationParameters);
        }
    {
