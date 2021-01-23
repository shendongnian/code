    namespace AvalonDemo
    {
        public partial class TestWindow : Window
        {
            public AvalonTestModel ViewModel { get; set; }
            public TestWindow()
            {
                ViewModel = new AvalonTestModel();
                InitializeComponent();
            }
        }
    }
