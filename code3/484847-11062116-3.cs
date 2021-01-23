    public partial class Window1 : Window
    {
        public static EventHandler HandleDisplaySettingsChanged = 
            new EventHandler(SystemEvents_DisplaySettingsChanged);
        public Window1()
        {
            InitializeComponent();
            Microsoft.Win32.SystemEvents.DisplaySettingsChanged += HandleDisplaySettingsChanged;
        }
        public void Close()
        {
            SystemEvents.DisplaySettingsChanged -= HandleDisplaySettingsChanged;
        }
        public static void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {
            Console.WriteLine("display settings changed");
            // change treeview size as you think what is appropriate here...
        }
    }
