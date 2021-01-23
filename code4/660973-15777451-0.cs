    class SettingsForm
    {
        public void OnTimerEvent(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
    class RTimer
    {
        Timer timer = new Timer();
        public void StartTimer(SettingsForm settingForm)
        {
            timer.Tick += settingForm.OnTimerEvent;
            timer.Interval = 5000;
            timer.Enabled = true;
        }
    }
