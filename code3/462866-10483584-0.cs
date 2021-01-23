    private int currentSongIndex = -1;
    void Player_MediaEnded(object sender, EventArgs e)
    {
        if(currentSongIndex == -1)
        {
            currentSongIndex = listBox.SelectedIndex;
        }
        currentSongIndex++;
        if(currentSongIndex < listBox.Items.Count)
        {
            player.Play(listBox.Items[currentSongIndex]);
        }
        else
        {
            // last song in listbox has been played
        }
    }
