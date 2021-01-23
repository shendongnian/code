    void watcher_Created(object sender, FileSystemEventArgs e)
        {
            try
            {
                //Your logic
            }
            catch (Exception ex)
            {
                Logger.Log(ex, e.Name);
                //To show your logs in grid
                dataGridView.DataSource = Logger.Logs;
            }
        }
