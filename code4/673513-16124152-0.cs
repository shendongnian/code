      private void button2_Click(object sender, RoutedEventArgs e)
        {
            if (!maximized)
            {
               
                this.FormBody.Width = SystemParameters.WorkArea.Width; //rectangle's width
                this.FormBody.Height = SystemParameters.WorkArea.Height;// rectangle's height
                this.WindowState = System.Windows.WindowState.Maximized;
                maximized = true;
            }
            else
            {
                this.WindowState = System.Windows.WindowState.Normal;
                maximized = false;
            }
        }
