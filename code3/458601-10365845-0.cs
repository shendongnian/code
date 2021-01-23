    private void btnEnlargeEllipses_Click(object sender, RoutedEventArgs e)
        {
            foreach (UIElement control in MainCanvas.Children)
            {
                Ellipse ellipse = (control as Ellipse);
                if (ellipse != null)
                {
                    ellipse.Width += 1;
                    ellipse.Height += 1;
                }
            }
        }
