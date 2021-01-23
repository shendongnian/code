    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Input;
    namespace BinaryTextBox
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void txtBinary_PreviewTextInput(object sender,
                     TextCompositionEventArgs e)
            {
                e.Handled = e.Text != "0" && e.Text != "1";
            }
            private void txtBinary_Pasting(object sender, DataObjectPastingEventArgs e)
            {
                if (!Regex.IsMatch(e.DataObject.GetData(typeof(string)).ToString(), "^[01]+$"))
                {
                    e.CancelCommand();
                }
            }
        }
    }
