    public abstract class DetailViewModelBase
    {
        protected DetailViewModelBase()
        {
            Timer = new List<long>();
        }
        public List<long> Timer { get; set; }
    }
    public class ReferenceDetailsViewModel : DetailViewModelBase
    {
        public IEnumerable<Reference.Grid> Grid { get; set; }
    }
    public class ContentDetailViewModel : DetailViewModelBase
    {
        public IEnumerable<Content.Grid> Detail { get; set; }
        public SelectList Statuses { get; set; }
        public SelectList Types { get; set; }
    }
  
