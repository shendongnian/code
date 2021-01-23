        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
    
            private void tgbtnTextBoxVisibility_Click(object sender, RoutedEventArgs e)
            {
                ToggleButton tgbtnTextBoxes=sender as ToggleButton;
    
                if (tgbtnTextBoxes.IsChecked.HasValue && tgbtnTextBoxes.IsChecked.Value)
                    spTextBoxes.Visibility = Visibility.Visible;
                else
                    spTextBoxes.Visibility = Visibility.Collapsed; //Note: Visibility.Collapsed will resize the layout where as Visibility.Hidden will not.
            }
    
            private void tgbtnTextBlockVisibility_Click(object sender, RoutedEventArgs e)
            {
                ToggleButton tgbtnTextBlocks = sender as ToggleButton;
    
                if (tgbtnTextBlocks.IsChecked.HasValue && tgbtnTextBlocks.IsChecked.Value)
                    spTextBlocks.Visibility = Visibility.Visible;
                else
                    spTextBlocks.Visibility = Visibility.Collapsed; //Note: Visibility.Collapsed will resize the layout where as Visibility.Hidden will not.
            }
        }
