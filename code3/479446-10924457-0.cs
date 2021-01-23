        //(Snip)
    
        //in download_button_Click, pass the row you are updating to the event.
        for (int z = 1; z < CheckedCount; z++)
        {             
            _MultipleWebClients = new WebClient();
    
            _MultipleWebClients.DownloadFileCompleted += new AsyncCompletedEventHandler(_DownloadFileCompleted);
            _MultipleWebClients.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(_DownloadProgressChanged);
            _MultipleWebClients.DownloadFileAsync(new Uri(_downloadUrlList[z].ToString()), @"F:\test" + z + ".mp4", dataGridView1.Rows[z]);     
        }
    }
    private void _DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
    {
        var rowToUpdate = (DataGridViewRow)e.UserState;
        RowToUpdate["ProgressBar"].Value = e.ProgressPercentage;
        RowToUpdate["TextProgress"].Value = e.ProgressPercentage;
        RowToUpdate["BytesToRecive"].Value = ((e.TotalBytesToReceive / 1024) / 1024).ToString();
        double dn = (double)e.BytesReceived / 1024.0 / (DateTime.Now - start).TotalSeconds;
        RowToUpdate["Speed"].Value = (dn.ToString("n") + " KB/s) " + e.ProgressPercentage);
    }
