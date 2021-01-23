    public class SettingsForm
    {
        public SettingsForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
        }
        public void Apple()
        {
            this.mainForm.TopMost = true;
        }
        private readonly MainForm mainForm;
    }
    public class MainForm
    {
        public void Banana()
        {
            var settingsForm = new SettingsForm(this);
            settingsForm.ShowDialog();
        }
    }
