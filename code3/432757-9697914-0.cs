    namespace Bouncing_Ball
    {
        public partial class MainPage : PhoneApplicationPage
        {
            public int RandomNumber { get; set; }
            public int GenerateRandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }
            public MainPage()
            {
                this.RandomNumber = GenerateRandomNumber(50, 350);
                InitializeComponent();
                this.DataContext = this;
            }
        }
    }
