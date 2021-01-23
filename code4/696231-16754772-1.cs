    
    // In about page
    protected override void OnNavigatedTo(NavigationEventArgs e) {
      base.OnNavigatedTo(e);
      System.Windows.Input.Touch.FrameReported -= App.MainPage.Touch_FrameReported;
    }
