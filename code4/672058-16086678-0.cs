       private void _sliderVideoPosition_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _adjustingVideoPositionSlider = true;
            _mediaElement.Pause();
        }
    
        private void _sliderVideoPosition_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _adjustingVideoPositionSlider = false;
            _mediaElement.Play();
        }
    
        private void _sliderVideoPosition_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (_adjustingVideoPositionSlider)
            {
                _mediaElement.Position = new TimeSpan(0, 0, 0, 0, (int) e.NewValue);
            }
        }
