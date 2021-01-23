    using System;
    using System.Windows;
    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
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
