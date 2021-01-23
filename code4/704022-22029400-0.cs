        public object GetProjects(ODataQueryOptions<Project> query)
        {
            var context = new ORM_Context();
            var projects = query.ApplyTo(context.Projects);
            var projectDTOs = projects.Select(
                    x =>
                    new ProjectDTO
                        {
                            Id = x.Id,
                            Name = x.Name
                        });
            return new
            {
                TotalCount = projects.Count(),
                Results = projectDTOs.ToList()
            };
        }
