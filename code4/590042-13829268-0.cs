    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            panel.Children.Add(new MyTextBox { Number = 123 });
            panel.Children.Add(new MyTextBox { Number = 321 });
            panel.Children.Add(new MyTextBox { Number = 456 });
            panel.Children.Add(new MyTextBox { Number = 654 });
        }
        private void click(object sender, RoutedEventArgs e)
        {
            var myTextBoxes = panel.Children.OfType<MyTextBox>();
            var numbers = string.Empty;
            myTextBoxes.ToList().ForEach(p => numbers += p.Number + Environment.NewLine);
            MessageBox.Show(numbers);
        }
    }
    //Subclass of TextBox that just adds one property
    public class MyTextBox : TextBox
    {
        public int Number { get; set; }
    }
