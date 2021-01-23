    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            Label[] myLabels = new Label[4];
            public MainWindow()
            {
                InitializeComponent();
            
                myLabels[0]=label1;
                myLabels[1]=label2;
                myLabels[2]=label3;
                myLabels[3]=label4;
            
            }
            private void checkedChanged(object sender, RoutedEventArgs e)
            {
                CheckBox cb = (CheckBox)sender;
                int index;
                if (int.TryParse(cb.Tag.ToString(), out index))
                {
                    if (cb.IsChecked == true)
                    {
                        myLabels[index].Content="Checked";
                    }
                    else if (cb.IsChecked == false)
                    {
                        myLabels[index].Content="UnChecked";
                    }
                    else
                    {
                        myLabels[index].Content="?";
                    }
                }
            }
        }
    }
