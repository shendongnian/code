    protected override void OnBackKeyPress( System.ComponentModel.CancelEventArgs e )
    {    
       if (myControl.Visibility == Visibility.Visible)
       {
          e.Cancel = true;
          myControl.Visibility = Visibility.Collapsed;
          }        
    }
