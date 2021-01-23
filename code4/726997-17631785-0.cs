    public abstract class CommonUIControls {
        public static Button nextButton = null;
    }
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            CommonUIControls.nextButton = nextButton;
        }
    }
