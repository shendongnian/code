    using System;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Input;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            private class HeavyObject : UserControl
            {
                private byte[] x = new byte[750000000];
                public HeavyObject()
                {
                    for (int i = 0; i < 750000000; i++ )
                    {                    
                        unchecked
                        {
                            x[i] = (byte)i;       
                        }
                    }
                    // Release optimisation will not compile the array
                    // unless you initialize and use it. 
                    Content = "Loads a memory!! " + x[1] + x[1000]; 
                }
            }
            const string msg = " ... nulled the HeavyObject ...";
            public MainWindow()
            {
                InitializeComponent();
                window.Content = msg;
            }
            private void window_MouseDown(object sender, MouseEventArgs e)
            {
                if (window.Content.Equals(msg))
                {
                    window.Content = new HeavyObject();
                }
                else
                {
                    window.Content = msg;
                }
            }
        }
    }
