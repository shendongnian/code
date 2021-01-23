    public class MyBase
    {
        // This is the .NET class you're inheriting from, just putting it as a placeholder.
    }
    public class MyReader : MyBase
    {
        private static IMySettings settings = MySettings.Instance;
    }
    public class MyWriter : MyBase
    {
        private static IMySettings settings = MySettings.Instance;
    }
    internal interface IMySettings
    {
        // Define your setting's properties, such as delimiter character.
    }
    internal sealed class MySettings : IMySettings
    {
        private MySettings()
        {
        }
        public static IMySettings Instance
        {
            get
            {
                return Nested.Instance;
            }
        }
        // Implement your setting's properties, such as delimiter character.
        private static class Nested
        {
            private static readonly IMySettings instance = new MySettings();
            // Explicit static constructor to tell C# compiler not to mark type as beforefieldinit
            static Nested()
            {
            }
            public static IMySettings Instance
            {
                get
                {
                    return instance;
                }
            }
        }
    }
