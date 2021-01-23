    /// <summary>
    /// Opens <see cref="Hyperlink.NavigateUri"/> in a default system browser
    /// </summary>
    public class ExternalBrowserHyperlink : Hyperlink
    {
        public ExternalBrowserHyperlink()
        {
            RequestNavigate += OnRequestNavigate;
        }
        private void OnRequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }
