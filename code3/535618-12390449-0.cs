    public abstract class GridViewModel<TGrid> where T : IGrid {
        protected GridViewModel() {
            Timer = new List<long>();
        }
        
        public List<long> Timer { get; set; }
        public IEnumerable<TGrid> Details { get; set; }
    }
    public class ReferenceDetailsViewModel : GridViewModel<Reference.Grid> { 
        
    }
    public class ContentDetailsViewModel : GridViewModel<Content.Grid> {
        public SelectList Statuses { get; set; }
        public SelectList Types { get; set; }
        public List<long> Timer { get; set; }
    }
