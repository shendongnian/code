    public ShowViewModel CreateShowViewModel(Show show,
                           List<EpisodeViewModel> episodes = null /* guessing type */)
    {
        return new ShowViewModel
        {
              ShowID = show.ShowID,
              Title = show.Title
              Episodes = episodes ?? CreateEpisodeViewModels(show.Episodes)
        };
    }
    public EpisodeViewModel CreateEpisodeViewModel(Episode episode,
                                                    ShowViewModel show = null)
    {
          return new EpisodeViewModel
          {
               ShowID = episode.ShowID,
               EpisodeID = episode.EpisodeID,
               Title = episode.Title,
               Show = show ?? CreateShowViewModel(episode.Show)
         };
     }
