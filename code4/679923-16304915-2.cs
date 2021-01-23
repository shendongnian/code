    public class MyViewModel
    {
        public MyViewModel(IEnumerable<Posts> posts, 
                           IEnumerable<Leaderboard> leaderboard)
        {
            //you can add null checks to ensure view model invariants
            this.Posts = posts;
            this.Leaderboard = leaderboard;
        }
        public IEnumerable<Posts> Posts { get; private set; }
        public IEnumerable<Leaderboard> Leaderboard{ get; private set; }
    }
