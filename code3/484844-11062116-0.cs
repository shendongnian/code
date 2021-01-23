    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            SystemEvents.DisplaySettingsChanged += new
                EventHandler(SystemEvents_DisplaySettingsChanged);
        }
        void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Debug.WriteLine("display settings changed");
            // change treeview size as you think what is appropriate here...
        }
    }
