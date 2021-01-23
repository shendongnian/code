    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
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
                DataContext = this;
                cbImageSelect.ItemsSource = new List<string>() { "test1.bmp", "test2.bmp" };
            }
    
            public static readonly DependencyProperty ImageUriProperty = DependencyProperty.Register("ImageUri", typeof(string), typeof(MainWindow));
    
            public string ImageUri
            {
                get { return (string)GetValue(ImageUriProperty); }
                set { SetValue(ImageUriProperty, value); }
            }
    
            private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                ImageUri = "pack://application:,,,/" + ((sender as ComboBox).SelectedItem as string);
            }
        }
    }
