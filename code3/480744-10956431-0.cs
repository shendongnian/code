    extern alias Aero;
    extern alias Luna;
    using System.Windows;
    namespace WpfApplication1
    {
      /// <summary>
      /// Interaction logic for MainWindow.xaml
      /// </summary>
      public partial class MainWindow: Window
      {
        public MainWindow()
        {
          InitializeComponent();
          var chrome1 = new Luna::Microsoft.Windows.Themes.ButtonChrome();
          var chrome2 = new Aero::Microsoft.Windows.Themes.ButtonChrome();
          MessageBox.Show(chrome1.GetType().AssemblyQualifiedName);
          MessageBox.Show(chrome2.GetType().AssemblyQualifiedName);
        }
      }
    }
