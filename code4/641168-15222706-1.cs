    public partial class LoginScreen : Form
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        public static string accountNo;
    }
    public class AnotherClass
    {
        string accountNo = LoginScreen.accountNo;
    }
