    IList<Project> projectList = new List<Project>();
    var ProjectSearchResult = new ProjectSearchResultController();
    var ProjectSearchCriteria = new GBLProjectSearchCriteria
    {
            ProjectName = projectName, SearchType = "P", QueryString = "?ProjectId="
    };
    var GBLProjectSearchResultListData = ProjectSearchResult.GetProjectSearchResultList(ProjectSearchCriteria);
    foreach (GBLProjectSearchResult item in GBLProjectSearchResultListData)
    {
        Project project = new Project();
        project.Id = item.Id;
        project.Title = item.Title;
        projectList.Add(project);
    }
    foreach (var project in projectList)
    {
        //seasons
        project.Seasons = new List<Seasons>();
        var SeasonSearchResult = new ProjectSearchResultController();
        var SeasonSearchCriteria = new GBLProjectSearchCriteria
        {
                Id = project.Key, ProjectName = projectName, SearchType = "S", QueryString = "?ProjectId=" + projectId + "&SeasonId=",
        };
        var GBLSeasonSearchResultListData = SeasonSearchResult.GetProjectSearchResultList(SeasonSearchCriteria);
        foreach (GBLProjectSearchResult item in GBLSeasonSearchResultListData)
        {
            Seasons season = new Seasons();
            season.Id = item.Id;
            season.Title = item.Title;
            project.Seasons.Add(season);
        }
        foreach (var season in project.Seasons)
        {
            //episodes
            season.Episodes = new List<Episodes>();
            var episodeSearchResult = new ProjectSearchResultController();
            var episodeSearchCriteria = new GBLProjectSearchCriteria
            {
                    Id = season.Key, ProjectName = projectName, SearchType = "E", QueryString = "?ProjectId=" + projectId + "&SeasonId=" + seasonId + "&EpisodeId=",
            };
            var GBLEpisodeSearchResultListData = episodeSearchResult.GetProjectSearchResultList(episodeSearchCriteria);
            foreach (GBLProjectSearchResult item in GBLEpisodeSearchResultListData)
            {
                Episodes episode = new Episodes();
                episode.Id = item.Id;
                episode.Title = item.Title;
                season.Episodes.Add(episode);
            }
        }
    }
