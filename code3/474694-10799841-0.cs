    private static IEnumerable<Project> GetMergedProjects(IEnumerable<List<Project>> projects)
    {
        var projectGrouping = projects.SelectMany(p => p).GroupBy(p => p.ProjectId);
        foreach (var projectGroup in projectGrouping)
        {
            yield return new Project
                                {
                                    ProjectId = projectGroup.Key,
                                    ProjectName =
                                        projectGroup.Select(p => p.ProjectName).FirstOrDefault(
                                            p => !string.IsNullOrEmpty(p)),
                                    Customer =
                                        projectGroup.Select(c => c.Customer).FirstOrDefault(
                                            c => !string.IsNullOrEmpty(c)),
                                    Address =
                                        projectGroup.Select(a => a.Address).FirstOrDefault(
                                            a => !string.IsNullOrEmpty(a)),
                                };
        }
    }
