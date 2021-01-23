    using Windows.Phone.Speech.VoiceCommands;
    
    
    private async void Application_Launching(object sender, 
      LaunchingEventArgs e)
    {
      try 
      {
        await VoiceCommandService.InstallCommandSetsFromFileAsync(
          new Uri("ms-appx:///SuperMusicFinderVCD.xml"));
      }
      catch (Exception ex)
      {
        // Handle exception
      }
    }
