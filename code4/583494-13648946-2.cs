    public class GetProjects : Command<IList<Project>>
    {
        public IList<int> IDs { get; set; }
        public override void Execute()
        {
            return DocumentSession.Query<Project>()...;
        }
    }
