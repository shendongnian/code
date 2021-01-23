    using System;
    using System.Collections.ObjectModel;
    using System.Windows;
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                Images.Add(new Tuple<string, string>("Picture 1", 
    "/WpfApplication1;component/Images/Picture 1.png"));
                Images.Add(new Tuple<string, string>("Picture 2", 
    "/WpfApplication1;component/Images/Picture 2.png"));
                Images.Add(new Tuple<string, string>("Picture 3", 
    "/WpfApplication1;component/Images/Picture 3.png"));
            }
            public static DependencyProperty ImagesProperty = DependencyProperty.Register(
    "Images", typeof(ObservableCollection<Tuple<string, string>>), typeof(MainWindow), 
    new PropertyMetadata(new ObservableCollection<Tuple<string, string>>()));
        
            public ObservableCollection<Tuple<string, string>> Images
            {
                get { return (ObservableCollection<Tuple<string, string>>)GetValue(
    ImagesProperty); }
                set { SetValue(ImagesProperty, value); }
            }
        }
    }
