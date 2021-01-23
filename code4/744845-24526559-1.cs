    private async void PhoneApplicationPage_BackKeyPress (object sender, System.ComponentModel.CancelEventArgs e)
    {
         e.Cancel = true;
         await Task.Delay(100);
         if (MessageBox.Show(msg, cap, MessageBoxButton.OKCancel) == MssageBoxResult.OK)
         {
              //somecode
         }                
    }
