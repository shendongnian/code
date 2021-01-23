    using System.Windows;
    namespace WpfApplication1
    {
        public partial class MyWindow : Window
        {
            // private, See Execute() instead
            MyWindow() {
                InitializeComponent();
            }
            static public void Execute(MyViewModel vm)
            {
                MyWindow Window = new MyWindow() {
                    DataContext = vm
                };
                Window.ShowDialog();
            }
        }
    }
