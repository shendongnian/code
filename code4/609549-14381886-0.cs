    public class DialogSettingsCancel
    {
        WindowSettings parent;
        public DialogSettingsCancel(WindowSettings settings)
        {
            this.parent = settings;        
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //Code to trigger when the "Yes"-button is pressed.
            this.parent.Close();
            this.Close();
        }
    }
