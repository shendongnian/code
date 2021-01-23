    void MouseDown(object sender, MouseButtonEventArgs args)
    {
        foreach (var img in ((Panel)sender).Children.OfType<Image>())
        {
            var w = new WriteableBitmap(img, null);
            var p = args.GetPosition(img);
            if (w.Pixels[w.PixelWidth * (int)p.Y + (int)p.X] != 0)
            {
                MessageBox.Show(string.Format("You clicked {0}!", img.Tag));
                args.Handled = true;
                break;
            }
        }
    }
