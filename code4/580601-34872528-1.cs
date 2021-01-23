        private void continue_Click(object sender, RoutedEventArgs e)
        {
            if (Convert.ToInt32(slider1.Value) > 1)
            {
                Worldmap.Properties.Settings.Default.value1 = Convert.ToInt32(slider1.Value);
                Worldmap.Properties.Settings.Default.value2 = Convert.ToInt32(slider2.Value);
                Worldmap.Properties.Settings.Default.Save();
                newForm2 = new WpfApplication1.GameWindow();
                newForm2.Show();
                Close();
            }
        }
>    
        private void slider1_ValueChanged_1(object sender, RoutedPropertyChangedEventArgs<double> e)
        { playerresult.Content = Convert.ToInt32(slider1.Value); }
