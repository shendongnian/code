     using System.Windows;
     using System.Windows.Input;
     using System.Diagnostics;
     namespace Test
     {
         public partial class MainWindow : Window
         {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void OnMouseMove(object sender, MouseEventArgs e)
            {
                Debug.WriteLine(Mouse.GetPosition(canvas1));
            }
        }
    }
