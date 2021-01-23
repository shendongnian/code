    using System;
    using System.Windows;
    namespace WpfApplication1
    {
        public partial class FlightWindow : Window
        {
            public FlightWindow()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }
        }
    }
