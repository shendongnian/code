    namespace ScreenSystem
    {
        internal class ScreenManager
        {
            public string Test { get; set; }
        }
    }
    
    namespace ScreenSystem
    {
        public class Screen
        {
            public ScreenManager Manager
            {
                get; internal set;
            }
        }
    }
