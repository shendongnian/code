    public partial class Window1 : Window
    {
        public EventHandler HandleDisplaySettingsChanged = new
                EventHandler(SystemEvents_DisplaySettingsChanged);
        public Window1()
        {
            InitializeComponent();
            SystemEvents.DisplaySettingsChanged += 
        }
        public void Close()
        {
            SystemEvents.DisplaySettingsChanged -= HandleDisplaySettingsChanged;
        }
        void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("display settings changed");
            // change treeview size as you think what is appropriate here...
        }
    }
