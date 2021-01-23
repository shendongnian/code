    public class AppForm : Form
    {
        public AppForm()
        {
            InitializeComponent();
            This.Icon = MyAppSettings.AppIcon; <--read here
            this.Text  = "App Text"
        }
    }
