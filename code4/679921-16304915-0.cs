    public class MyViewModel
    {
        public MyViewModel(IEnumerable<Posts> posts, 
                           IEnumerable<Leaderboard> leaderboard)
        {
            this.Posts = posts;
            this.Leaderboard = leaderboard;
        }
        public IEnumerable<Posts> Posts { get; private set; }
        public IEnumerable<Leaderboard> Leaderboard{ get; private set; }
    }
