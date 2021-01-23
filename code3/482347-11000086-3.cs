    public partial class MainWindow : Window
        {
    
            public bool CountSumSwitch
            {
                get { return (bool)GetValue(CountSumSwitchProperty); }
                set { SetValue(CountSumSwitchProperty, value); }
            }
    
            public static readonly DependencyProperty CountSumSwitchProperty = DependencyProperty.Register("CountSumSwitch", typeof(bool), typeof(MainWindow), new UIPropertyMetadata(false));
    
    
            public List<TheItem> ITems
            {
                get { return (List<TheItem>)GetValue(ITemsProperty); }
                set { SetValue(ITemsProperty, value); }
            }
    
            public static readonly DependencyProperty ITemsProperty = DependencyProperty.Register("ITems", typeof(List<TheItem>), typeof(MainWindow), new UIPropertyMetadata(null));
    
    
            public MainWindow()
            {
                InitializeComponent();
    
                Random rnd = new Random();
    
                ITems = new List<TheItem>(new TheItem[]
                {
                    new TheItem () { Name = "Item 1", Count = rnd.Next(100), Sum = rnd.Next (100)}, 
                    new TheItem () { Name = "Item 2", Count = rnd.Next(100), Sum = rnd.Next (100)}, 
                    new TheItem () { Name = "Item 3", Count = rnd.Next(100), Sum = rnd.Next (100)}, 
                    new TheItem () { Name = "Item 4", Count = rnd.Next(100), Sum = rnd.Next (100)}, 
                    new TheItem () { Name = "Item 5", Count = rnd.Next(100), Sum = rnd.Next (100)}, 
                    new TheItem () { Name = "Item 6", Count = rnd.Next(100), Sum = rnd.Next (100)}, 
                    new TheItem () { Name = "Item 7", Count = rnd.Next(100), Sum = rnd.Next (100)}, 
                    new TheItem () { Name = "Item 8", Count = rnd.Next(100), Sum = rnd.Next (100)}, 
                    new TheItem () { Name = "Item 9", Count = rnd.Next(100), Sum = rnd.Next (100)}, 
                });
    
                CountSumSwitch = false;
            }
    
            public class TheItem
            {
                public string Name { get; set; }
                public int Count { get; set; }
                public int Sum { get; set; }
            }
        }
