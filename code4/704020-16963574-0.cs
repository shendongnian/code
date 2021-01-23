    using(var context = new ORM_Context())
    {
        var projects = context.Projects; // IQueryable<Project>
        //Create a set of ODataQueryOptions for the internal class
        ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
        modelBuilder.EntitySet<Project>("Project"); 
        var context = new ODataQueryContext(
             modelBuilder.GetEdmModel(), typeof(Project));
        var newOptions = new ODataQueryOptions<Project>(context, Request);
        var t = new ODataValidationSettings() { MaxTop = 25 };
        var s = new ODataQuerySettings() { PageSize = 25 };
        newOptions.Validate(t);
        IEnumerable<Project> internalResults =
            (IEnumerable<Project>)newOptions.ApplyTo(projects, s);
        int skip = newOptions.Skip == null ? 0 : newOptions.Skip.Value;
        int take = newOptions.Top == null ? 25 : newOptions.Top.Value;
        var projectDTOs =
                internalResults.Skip(skip).Take(take).Select(x =>
                    new ProjectDTO
                        {
                            Id = x.Id,
                            Name = x.Name
                        });
        var projectsQueriedList = projectDtos.ToList();
        var result = new ODataQueryResult<ProjectDTO>(
            projectsQueriedList, totalCount);
        return result;
    }
