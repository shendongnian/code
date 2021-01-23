    ie.ProgressChanged += new WebBrowserProgressChangedEventHandler(_ie);
    private void _ie(object sender, WebBrowserProgressChangedEventArgs e)
    {
      int max = (int)Math.Max(e.MaximumProgress, e.CurrentProgress);
      int min = (int)Math.Min(e.MaximumProgress, e.CurrentProgress);
      if (min.Equals(max))
      {
       //Run your code here when page is actually 100% complete
      }
    }
    
