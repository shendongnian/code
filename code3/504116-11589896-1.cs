    private void zoomSlider_ValueChanged_1(object sender, Windows.UI.Xaml.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            try
            {
                zoom.ScaleX = zoomSlider.Value;
                zoom.ScaleY = zoomSlider.Value;
                zoom.CenterX = 683;
                zoom.CenterY = 384;
            }
            catch (Exception)
            {
            }
        }
             
