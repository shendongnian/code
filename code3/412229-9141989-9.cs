            [ProvideSelectData("Teams")]
            public IEnumerable Teams()
            {
                return _teamsRepository.All.ToSelectList(a => a.Name, a => a.TeamId);
            }
