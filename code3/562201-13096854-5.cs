    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Window2.xaml
        /// </summary>
  
       public partial class Window2 : Window
       {
            public delegate void myCustomEventHandler(object sender, myCustomEventArgs e);
            public event myCustomEventHandler RaiseCustomEvent;
            String myStatement = "Hello World";
            public Window2()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                myCustomEventArgs ea = new myCustomEventArgs( myStatement);
                RaiseCustomEvent(sender, ea);
            }
        }
        public class myCustomEventArgs : EventArgs
        {
            public myCustomEventArgs(string s)
            {
                myString = s;
            }
            private string myString;
            public string retrieveString
            {
                get { return myString; }
            }
        }
    }
