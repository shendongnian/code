    public void ChangeLogMessage(Uri repositoryRoot, long revision, string newMessage)
    {
        using (SvnClient client = e.GetService<ISvnClientPool>().GetClient())
        {
            SvnSetRevisionPropertyArgs sa = new SvnSetRevisionPropertyArgs();
            // Here we prevent an exception from being thrown when the 
            // repository doesn't have support for changing log messages
            sa.AddExpectedError(SvnErrorCode.SVN_ERR_REPOS_DISABLED_FEATURE);
            client.SetRevisionProperty(repositoryRoot, 
                revision, 
                SvnPropertyNames.SvnLog, 
                newMessage, 
                sa);
            if (sa.LastException != null &&
                sa.LastException.SvnErrorCode == 
                    SvnErrorCode.SVN_ERR_REPOS_DISABLED_FEATURE)
            {
                MessageBox.Show(
                    sa.LastException.Message, 
                    "", 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);
            }
        }
    }
