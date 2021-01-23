    private void bGetLatestPosts_Click(object sender, EventArgs e)
    {
        backgroundWorker.RunWorkerAsync();
    }
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        e.Result = getLatestPosts();
    }
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error != null)
        {
            // Handle exception...
        }
        else
        {
            List<Post> result = (List<Post>)e.Result;
            // Update GUI...
        }
    }
