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
                
                myClass.DoSomething(); // this will call the event handler and display the message in the textbox.
                // we subscribed to the event. MyClass doesn't need to know anything about the textbox.
            }
            
            // event handler
            void myClass_OnSendMessage(string message)
            {
                tbMessage.Text = message;
            }
        }
    }
