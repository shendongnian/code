        private void WindowSizeChanged(object sender, WindowSizeChangedEventArgs e)
        {
             if(ApplicationView.Value == ApplicationViewState.Snapped)
              {
                   backButton.Click += snapped_back_click;
              }
              else
              {
                   //something else
              }
        }
