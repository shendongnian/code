     private void slider1_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider1 == null || slider2 == null)
                return;
            if (slider1.Value >= slider2.Value)
            {
                slider2.Value = slider1.Value;
            }
          
           
        }
        private void slider2_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (slider1 == null || slider2 == null)
                return;
            if (slider2.Value <= slider1.Value)
            {
                slider1.Value = slider2.Value;
            }
        }
