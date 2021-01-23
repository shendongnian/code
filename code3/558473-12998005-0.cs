    public class AppleTree
    {
        private readonly IFruit _apple;
        public AppleTree(IFruit apple)
        {
            _apple = apple;
        }
        public string GetApple()
        {
            return _apple.ToString();
        }
    }
