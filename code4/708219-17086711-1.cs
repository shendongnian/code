    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        var list = new List<ViewModel>() 
        {
            new ViewModel(110, Colors.LawnGreen),
            new ViewModel(50, Colors.DarkBlue),
            new ViewModel(130, Colors.Firebrick),
            new ViewModel(60, Colors.RosyBrown),
            new ViewModel(100, Colors.IndianRed),
            new ViewModel(210, Colors.BurlyWood),
            new ViewModel(150, Colors.Turquoise)
        };
    
        gv.ItemsSource = list;
    }
    
    public class ViewModel
    {
        public double MyWidth { get; set; }
        public Color MyColor { get; set; }
    
        public ViewModel(double _MyWidth, Color _MyColor)
        {
            MyWidth = _MyWidth;
            MyColor = _MyColor;
        }
    }
