    namespace khaosInstallerWPF
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                MouseDown += delegate { DragMove(); };
            }
        }
    }
 
