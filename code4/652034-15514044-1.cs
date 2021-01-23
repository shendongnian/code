    private void pictureBox20_Click(object sender, EventArgs e)
    {
        const bool loopPlayer = true;
        if (label30.Text == "Waiting 15.wav")
        {
            MessageBox.Show("No beat loaded");
            return;
        }
        var player = new System.Windows.Media.MediaPlayer();
        try
        {
            player.Open(new Uri(label51.Text));
            if(loopPlayer)
                player.MediaEnded += MediaPlayer_Loop;
            player.Play();
        }
        catch (FileNotFoundException)
        {
            MessageBox.Show("File has been moved." + "\n" + "Please relocate it now!");
        }
    }
