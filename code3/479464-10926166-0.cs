    // Note: All classes and structs go in the same namespace, but each goes in its own .cs file.
    
    // Use a struct, rather than a class, when you just need a small set of values to pass around
    struct MySettings
    {
        public int NumberOfWidgets { get; set; }
        public string GadgetFilename { get; set; }
        public bool LaunchRocket { get; set; }
    }
    
    partial class MyForm
    {
        // ...constructor, etc.
        
        private void ButtonForTask1_Clicked(object sender, EventArgs e)
        {
            var settings = ReadSettingsFromControls();
            var task1 = new Task1(settings);
            task1.DoTheTask(ref this.WebBrowserControl1);
        }
        
        private void ButtonForTask2_Clicked(object sender, EventArgs e)
        {
            var settings = ReadSettingsFromControls();
            var task2 = new Task2(settings);
            task2.DoTheTask(ref this.WebBrowserControl1);
        }
        
        // ... and so on for the other tasks
        
        private MySettings ReadSettingsFromControls()
        {
            return new MySettings
            {
                NumberOfWidgets = int.Parse(this.txt_NumWidgetsTextBox.Text),
                GadgetFilename = this.txt_GadgetFilenameTextBox.Text,
                LaunchRocket = this.chk_LaunchPermission.Checked
            };
        }
    }
    
    class Task1
    {
        // Readonly so it can only be set in the constructor.
        // (You generally don't want settings changing while you're running. :))
        private readonly MySettings _settings;
        
        public Task1(MySettings settings)
        {
            _settings = settings;
        }
        
        public void DoTheTask(ref WebBrowser browserControl)
        {
            // TODO: Do something with _settings.NumberOfWidgets and browserControl
            // You can use private helper methods in this class to break out the work better
        }
    }
    
    class Task2 { /* Like Task1... */ }
