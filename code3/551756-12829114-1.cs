    public class SearchModel
    {
      private Lazy<List<TagDetails>> tags = new Lazy(() => new List<TagDetails>());
      public List<TagDetails> Tags
      {
        get { return this.tags.Value; }
      }
    }
