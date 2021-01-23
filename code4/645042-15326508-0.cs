     //Put this in your main method
     LoadSound("sfx/piano.wav", out _BGMUSIC);
     //put this method in the same class
     private void LoadSound(String SoundFilePath, out SoundEffect Sound)
            {
                // For error checking, assume we'll fail to load the file.
                Sound = null;
    
                try
                {
                    // Holds informations about a file stream.
                    StreamResourceInfo SoundFileInfo = App.GetResourceStream(new Uri(SoundFilePath, UriKind.Relative));
    
                    // Create the SoundEffect from the Stream
                    Sound = SoundEffect.FromStream(SoundFileInfo.Stream);
                    FrameworkDispatcher.Update();
                }
                catch (NullReferenceException)
                {
                    // Display an error message
                    MessageBox.Show("Couldn't load sound " + SoundFilePath);
                }
            }
