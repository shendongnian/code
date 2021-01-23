    using System.Windows;
    using System.Windows.Documents;
    namespace AnimAdornerTest
    {
        public partial class MainWindow : Window
        {
            private AdornerLayer _adornerLayer;
            private AnimAdorner _adorner;
            public MainWindow()
            {
                InitializeComponent();
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (_adornerLayer == null)
                {
                    _adornerLayer = AdornerLayer.GetAdornerLayer(toBeAdorned);
                }
                if (_adorner != null)
                {
                    _adornerLayer.Remove(_adorner);
                }
                _adorner = new AnimAdorner(toBeAdorned);
                _adornerLayer.Add(_adorner);
            }
        }
    }
