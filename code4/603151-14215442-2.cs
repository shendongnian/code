    static void Main(string[] args)
    {
        var usersList = new List<User>()
                        {
                            new User() {UserID = 1},
                            new User() {UserID = 2},
                            new User() {UserID = 3}
                        };
        var userLinksList = new List<RoleUserLink>()
                            {
                                new RoleUserLink() {UserID = 1, State = "del"},
                                new RoleUserLink() {UserID = 2, State = "add"},
                                new RoleUserLink() {UserID = 2, State = "del"}
                            };
        IEnumerable<User> z = (from users in usersList 
                               join roleUserLinks in userLinksList
                               on users.UserID equals roleUserLinks.UserID into roleUserLinksJoin
                               // left join
                               from roleUserLinks in roleUserLinksJoin.DefaultIfEmpty()
                               where
                                // has never been added to a role ie record isn't there
                                    roleUserLinks == null
                                // has been soft deleted from a role so we want this record
                                    || roleUserLinks.State == "del"
                                // has been added to role so we don't want this record
                                    && !roleUserLinksJoin.Where(x=> x.State == "add" && x.UserID == roleUserLinks.UserID).Any()
                                select users).Distinct();
        var res = z.ToList();
    }
    public class User
    {
        public int UserID { get; set; }
    }
    public class RoleUserLink
    {
        public int UserID { get; set; }
        public string State { get; set; }
    } 
