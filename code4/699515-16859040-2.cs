    public class PlayerSearchHandler : ContentHandler
    {
        public PlayerSearchHandler()
        {
            Filters.Add(new ActivatingFilter<PlayerSearchPart>("PlayerSearch"));
        }
    }
