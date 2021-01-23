    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            // because the code 'this.FindName("lineChartMood")' doesn't work in the constructor, I'll use the following line:
            this.lineChartMood = this.myChart.Series.OfType<LineSeries>().First(ls => ls.Name == "lineChartMood");
            
            // other code
        }
    
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.lineChartMood.PolylineStyle = (Style)this.Resources["PolylineStyle2"];
            this.lineChartMood.Refresh(); // you should call this method so that the style is applied
        }
    }
