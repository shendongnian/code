    public class GetUsers : Command<IList<User>>
    {
        public IList<int> IDs { get; set; }
        public override void Execute()
        {
            return DocumentSession.Query<User>()...;
        }
    }
