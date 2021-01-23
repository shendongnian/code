        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.img1.Visibility == System.Windows.Visibility.Visible)
            {
                this.img1.Visibility = System.Windows.Visibility.Hidden;
                this.img2.Visibility = System.Windows.Visibility.Visible;
            }
            else
            {
                this.img1.Visibility = System.Windows.Visibility.Visible;
                this.img2.Visibility = System.Windows.Visibility.Hidden;
            }
        }
