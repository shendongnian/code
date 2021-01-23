    namespace System.Windows.Controls
    {
        public class UnchangingCheckBox : System.Windows.Controls.CheckBox
        {
            public UnchangingCheckBox()
            {
                this.Click += new System.Windows.RoutedEventHandler(UnchangingCheckBox_Click);
            }
    
            void UnchangingCheckBox_Click(object sender, System.Windows.RoutedEventArgs e)
            {
                if (((CheckBox)sender).IsChecked.HasValue)
                    ((CheckBox)sender).IsChecked = !((CheckBox)sender).IsChecked; 
            }
        }
    }
