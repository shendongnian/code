    public partial class Window1 : Window
    {
        public event EventHandler<CustomEventArgs> RaiseCustomEvent;
        public Window1()
        {
            InitializeComponent();
        }
        public string myText()
        {
            return textBox1.Text;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RaiseCustomEvent(this, new CustomEventArgs(textBox1.Text));
        }
    }
    public class CustomEventArgs : EventArgs
    {
        public CustomEventArgs(string s)
        {
            msg = s;
        }
        private string msg;
        public string Message
        {
            get { return msg; }
        }
    }
