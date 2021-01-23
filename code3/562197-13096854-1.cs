    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Window2.xaml
        /// </summary>
  
       public partial class Window2 : Window
       {
            public delegate void myCustomEventHandler(object sender, myCustomEventArgs e);
            public event myCustomEventHandler RaiseCustomEvent;
            Label myStatement = new Label();
            public Window2()
            {
                InitializeComponent();
                myStatement.Background = Brushes.Blue;
                myStatement.Content = "Hello World";
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                myCustomEventArgs ea = new myCustomEventArgs( myStatement);
                RaiseCustomEvent(sender, ea);
            }
        }
        public class myCustomEventArgs : EventArgs
        {
            public myCustomEventArgs(object o)
            {
                myObject = o;
            }
            private object myObject;
            public object retrieveObject
            {
                get { return myObject; }
            }
        }
    }
