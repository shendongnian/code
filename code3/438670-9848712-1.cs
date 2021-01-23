    void button2Click(object sender, RoutedEventArgs e)
        {
            if (e.RoutedEvent == FrameworkElement.LoadedEvent)
            {
                ToolTip t = new ToolTip();
                t.Content = "Something helpful";
                ((Button)sender).ToolTip = t;
                return;
            }
            //Logic for handling button clicks goes here
            MessageBox.Show("action 2");
        }
