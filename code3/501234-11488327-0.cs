    ...
    int currentPlayIndex = -1;
    
    ...
    mplayer.MediaEnded += OnMediaEnded;
    ...
    private void OnMediaEnded(object sender, EventArgs args)
    {
        // if we want to continue playing...
        PlayNextFile();
    }
     
    ...
    public void PlayNextFile()
    {
        PlayFiles(currentPlayIndex + 1);
    }
    public void PlayFiles(int index)  
    {  
        try  
        {  
            currentPlayIndex = -1;
            int eof = dgvTracks.Rows.Count;  
            for (int i = index; index <= eof; i++)  
            {  
                if (File.Exists(dsStore.Tables["Track"].Rows[i]["Filepath"].ToString()))  
                {  
                    currentPlayIndex = i;  // <--- save index
                    PlayFile(dsStore.Tables["Track"].Rows[i]["Filepath"].ToString());  
                    Application.DoEvents();  
                    Thread.Sleep(TimeSpan.FromSeconds(mplayer.AudioLength));  
                }  
                else  
                {  
                    Exception a = new Exception("File doesn't exists");  
                    throw a;  
                }  
            }  
        }  
        catch (Exception ex)  
        {  
            MessageBox.Show(ex.Message, ex.Message, MessageBoxButtons.OK);  
        }  
    }  
