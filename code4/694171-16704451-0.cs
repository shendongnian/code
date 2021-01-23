    MediaPlayer player = new System.Windows.Media.MediaPlayer();
    bool playing = false;
    private void Window_KeyDown(object sender, KeyEventArgs e)
    {
        if (playing == true)
        {
            return;
        }
        /* your code follows */
        try
        {
            player.Open(new Uri(label46.Text));
            player.Volume = (double)trackBar4.Value / 100;
            player.Play();
            playing = true;
        }
        catch (FileNotFoundException)
        {
            MessageBox.Show("File has been moved." + "\n" + "Please relocate it now!");
        }
    }
    private void Window_KeyUp(object sender, KeyEventArgs e)
    {
        if (playing == false)
        {
            return;
        }
        
        /* below code you need to copy to your Media Ended/Media Failed events */
        player.Stop();
        player.Close();
        playing = false;
    }
