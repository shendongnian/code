    void frame_NavigationFailed(object sender, System.Windows.Navigation.NavigationFailedEventArgs e)
    {
      e.Handled = true;
      // TODO: Goto an error page.
    }
    private void frame_Navigated(object sender,  System.Windows.Navigation.NavigationEventArgs e)
    {
      System.Diagnostics.Trace.WriteLine(e.WebResponse.Headers);
    }
