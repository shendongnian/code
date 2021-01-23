    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            var l = new List<lItem>();
            
            for(int i=0;i<5;i++)
            {
            l.Add(new lItem(true,"aaa"+i));
            l.Add(new lItem(false,"bbb"+i));
            }
    
            sads.ItemsSource = l;
    
        }
    }
    
    
    public class lItem
    {
        public string Text { get; set; }
        public Brush Color { get; set; }
        public HorizontalAlignment alig { get; set; }
    
        public lItem(bool ss, string str)
        {
            Text = str;
            Color = Brushes.Blue;
            alig = HorizontalAlignment.Right;
    
            if (ss)
            {
                Color = Brushes.Red;
                alig = HorizontalAlignment.Left;
            }
        }
    }
