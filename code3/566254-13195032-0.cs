    class ProjectView:
    {
        public Dependency[] Dependencies { get; set; }
        public List<Dependency> DependencyList { get { return this.Dependencies.ToList(); } }
    }
