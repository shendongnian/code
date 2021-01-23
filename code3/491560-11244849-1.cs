    private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                if (checkBox1checked)
                {
                    image1.BeginInit();
                    image1.Source = new BitmapImage(new Uri("/checkbox0.png", UriKind.RelativeOrAbsolute));
                    image1.EndInit();
                    checkBox1checked = false;
                }
                else
                {
                    image1.BeginInit();
                    image1.Source = new BitmapImage(new Uri("/checkbox1.png", UriKind.RelativeOrAbsolute));
                    image1.EndInit();
                    checkBox1checked = true;
                }
            }
        }
