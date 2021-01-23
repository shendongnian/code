    using System.Windows;
    using System.Xml;
    
    namespace TestWPFApp
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                this.Data.Document = new XmlDocument();
                this.Data.Document.LoadXml(@"<employee><general><description>Test Description</description></general></employee>");
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                var data = this.Data.Document.SelectSingleNode("descendant::description").InnerText;
            }
        }
    }
