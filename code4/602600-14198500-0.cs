    public class ProjectTypeIndex : AbstractIndexCreationTask<Project, ProjectTypeIndex.ReduceResult>
    {
        public class ReduceResult
        {
            public string ProjectType { get; set; }
        }
        public ProjectTypeIndex()
        {
            Map = projects => from project in projects
                                       from type in project.Type
                                       select new
                                           {
                                               ProjectType = type
                                           };
            Reduce = results => from result in results
                                group result by result.ProjectType into g
                                select new
                                    {
                                        ProjectType = g.Key
                                    };
        }
    }
