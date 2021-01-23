    //SvnUriTarget is a wrapper class for SVN repository URIs
    SvnUriTarget target = new SvnUriTarget(tbRepoURI.Text);
    
    Collection<SvnLogEventArgs> logitems = new Collection<SvnLogEventArgs>();
    
    SvnLogArgs arg = new SvnLogArgs();
    
    client.GetLog(new System.Uri(target.ToString()), arg, out logitems);
    
    foreach (var logentry in logitems)
    {
        MessageBox.Show(logentry.Revision + ": " + logentry.LogMessage);
    }
