    public class FindUsersBySearchTextQuery : IQuery<User[]>
    {
        public string SearchText { get; set; }
     
        public bool IncludeInactiveUsers { get; set; }
    }
