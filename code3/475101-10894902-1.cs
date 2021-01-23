    void AddMediaPlayer(string url) {
        try {
            var wmPlayer = new AxWMPLib.AxWindowsMediaPlayer();
    
            ((System.ComponentModel.ISupportInitialize)(wmPlayer)).BeginInit();
            wmPlayer.Name = "wmPlayer";
            wmPlayer.Enabled = true;
            wmPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Controls.Add(wmPlayer);
            ((System.ComponentModel.ISupportInitialize)(wmPlayer)).EndInit();
    
            // After initialization you can customize the Media Player
            wmPlayer.uiMode = "none";
            wmPlayer.URL = url;
        }
        catch { }
    }
