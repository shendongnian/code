    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    namespace WpfApplication1
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
        private void listbox1_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (listbox1.SelectedItems.Count > 0)
            {
                ListBoxItem mySelectedItem = listbox1.SelectedItem as ListBoxItem;
                if (mySelectedItem != null)
                {
                    DragDrop.DoDragDrop(listbox1, mySelectedItem.Content.ToString(), DragDropEffects.Copy);
                }
                
            }
        }
        private void textbox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effects = DragDropEffects.Copy;
        }
        private void textbox1_PreviewDragOver(object sender, DragEventArgs e)
        {
            e.Handled = true;
        }
        private void textbox1_Drop(object sender, DragEventArgs e)
        {
            string tstring;
            tstring = e.Data.GetData(DataFormats.StringFormat).ToString();
            textbox1.Text += " " + tstring;
        }
        private void textbox1_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
        }
    }
    }
