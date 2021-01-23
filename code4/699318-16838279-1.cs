    using System.Windows;
    
    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                MyClass myClass = new MyClass();
                myClass.Value1 = 1;
                myClass.Value2 = 2;
                DataContext = myClass;
            }
        }
    
        public class MyClass
        {
            public int Value1 { get; set; }
            public int Value2 { get; set; }
        }
    }
