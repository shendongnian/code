    namespace System.Windows.Controls
    {
        public class UnchangingCheckbox : System.Windows.Controls.CheckBox
        {
            public UnchangingCheckbox()
            {
                this.Click += new System.Windows.RoutedEventHandler(UnchangingCheckbox_Click);
            }
    
            void UnchangingCheckbox_Click(object sender, System.Windows.RoutedEventArgs e)
            {
                if (((CheckBox)sender).IsChecked.HasValue)
                    ((CheckBox)sender).IsChecked = !((CheckBox)sender).IsChecked; 
            }
        }
    }
