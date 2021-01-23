        public ShowViewModel CreateShowViewModel(Show show, List<EpisodeViewModel> episodes = null /* guessing type */) {
            var viewModel = new ShowViewModel {
                ShowID = show.ShowID,
                Title = show.Title
            };
            viewModel.Episodes = episodes ?? CreateEpisodeViewModels(show.Episodes, viewModel);
            return viewModel;
        }
        public EpisodeViewModel CreateEpisodeViewModel(Episode episode, ShowViewModel show = null) {
            var viewModel = new EpisodeViewModel {
                ShowID = episode.ShowID,
                EpisodeID = episode.EpisodeID,
                Title = episode.Title
            };
            viewModel.Show = show ?? CreateShowViewModel(episode.Show, viewModel); // this might cause a problem due to the fact that you only have 1 episode, and not all of them.
            return viewModel;
        }
