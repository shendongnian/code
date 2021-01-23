    // I changed the name class1 to MySettings
    public class MySettings
    {
        public bool ShouldTextBoxBeEnabled()
        {
            // Do some logic here.
            return true;
        }
        // Or static property (method if you like)
        public static StaticShouldTextBoxBeEnabled { get { return true; } }
    }
