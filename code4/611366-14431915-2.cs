       public class MyMessageBox : Window
       {
    
            private void OK_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = true;
            }
    
            private void Cancel_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = false;
            }
       }
