    protected override void OnPreviewKeyDown(System.Windows.Input.KeyEventArgs e)
    {
       var ue = e.OriginalSource as FrameworkElement;
    
       if (e.Key == Key.Enter)
       { 
          MessageBox.Show("You pressed enter! Good job!");
          e.Handled = true;   // to tell event stack you've already taken care of this condition
       }
       else if (e.KeyCode == Keys.Escape)
          MessageBox.Show("You pressed escape! What's wrong?");
    }
