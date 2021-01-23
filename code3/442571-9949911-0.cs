    private void getChangeParameters_Movilink(ParameterAddress sender, MovilinkEventArgs e)
    {
        label24.Dispatcher.BeginInvoke(
           (Action)(() =>
           {
              label24.Content = e.ActualValue.ToString();
           }));
    }
