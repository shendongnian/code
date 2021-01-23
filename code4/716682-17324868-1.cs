    private List<string> doNotFireTextBoxes = new List<string>();
    
    private void mytextbox_LostFocus(object sender, RoutedEventArgs e)
       {
          if (this.IsLoaded)
          {      
              System.Windows.Controls.TextBox textbox = (System.Windows.Controls.TextBox) sender;
              doNotFireTextBoxes.Add(textbox.Name)  
    
              if(textbox.Text.Contains('.'))
              {
                 textbox.Foreground = new SolidColorBrush(Colors.Gray);
                 textbox.Background = new SolidColorBrush(Colors.White);
              }
    
          }
       }
    
    private void mytextbox_TextChanged(object sender, TextChangedEventArgs e)
       {
          if (this.IsLoaded)
          {
             System.Windows.Controls.TextBox textbox = (System.Windows.Controls.TextBox) sender;
             if(!doNotFireTextBoxes.Contains(textbox.Name))
             {
                 if(textbox.Text.Contains('.'))
                 {
                    textbox.Foreground = new SolidColorBrush(Colors.White);
                    textbox.Background = new SolidColorBrush(Colors.Red);
                 }
             }
             doNotFireTextBoxes.Remove(txtBoxName)
           }
       }
