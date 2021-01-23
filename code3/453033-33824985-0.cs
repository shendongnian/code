    private void slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
       if(slider.OldValue != null)
       {
          textbox1.Text = silder1.Value.ToString();
       }
    }
