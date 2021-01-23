    link.RequestNavigate += LinkOnRequestNavigate;
    private void LinkOnRequestNavigate(object sender, RequestNavigateEventArgs e)
    {
        System.Diagnostics.Process.Start(e.Uri.ToString());
    }
