        int[] projectIDs = new int[Settings.Default.ResultsPerPage];
        foreach (ProjectFTS_DTO dto in 
                  RankedSearchResults
                  .Skip(Settings.Default.ResultsPerPage * (pageNum - 1))
                  .Take(Settings.Default.ResultsPerPage)) {
                     projectIDs[index] = dto.ProjectID;
                     index++;
                }
    
        IEnumerable<Project> projects = _repository.Projects
                    .Where(o=>projectIDs.Contains(o.ProjectID));
