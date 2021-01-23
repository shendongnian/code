    private void artistSong_Loaded(object sender, RoutedEventArgs e)
    {
      if (this.NavigationContext.QueryString != null
        && this.NavigationContext.QueryString.ContainsKey("voiceCommandName"))
      {
        // Page was launched by Voice Command
        string commandName =
          NavigationContext.QueryString["voiceCommandName"];
        string spokenNumber = "";
        if (commandName == "topSongs" &&
          this.NavigationContext.QueryString.TryGetValue("by", 
            out artist))
        {
         //do whatever you want to do
          }
        }
      }
    }
