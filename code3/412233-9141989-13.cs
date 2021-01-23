            [ProvideSelectData("Teams")]
            public IEnumerable Teams()
            {
                return _teamRepository.All.ToSelectList(a => a.Name, a => a.TeamId);
            }
