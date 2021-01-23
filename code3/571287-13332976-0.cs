    private void button1_Click(object sender, EventArgs e)
    {
        // Play sound
        this.playSound();
    
        // WAIT FOR END OF SOUND
    
        Close();
    }
    private void playSound()
    {
        Random random = new Random();
        // Create list of quit music
        List<System.IO.UnmanagedMemoryStream> sound = new List<System.IO.UnmanagedMemoryStream>
        {
            global::StrongholdCrusaderLauncher.Properties.Resources.sound_quit_1,
            global::StrongholdCrusaderLauncher.Properties.Resources.sound_quit_2,
            global::StrongholdCrusaderLauncher.Properties.Resources.sound_quit_3,
            global::StrongholdCrusaderLauncher.Properties.Resources.sound_quit_4,
        };
        // Random, set and play sound
        (new SoundPlayer(sound[random.Next(sound.Count)])).PlaySync(); //We've changed Play(); to PlaySync(); so that the Wave Sound file would be played in the main user interface thread
    }
