    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
                var myClass = new MyClass();
                myClass.OnSendMessage += new SendMessageDelegate(myClass_OnSendMessage); // subscribing to the event
                
                myClass.DoSomething(); // will call the event handler
            }
            
            // event handler
            void myClass_OnSendMessage(string message)
            {
                tbMessage.Text = message;
            }
        }
    }
