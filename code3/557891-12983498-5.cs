    // I changed the name class1 to MySettings
    public class MySettings
    {
        public bool ShouldTextBoxBeEnabled()
        {
            // Do some logic here.
            return true;
        }
        // More generic
        public static bool SetTextBoxState(TextBox textBox)
        {
            // Do some logic here.
            textBox.Enabled = true;
        }
        // Or static property (method if you like)
        public static StaticShouldTextBoxBeEnabled { get { return true; } }
    }
