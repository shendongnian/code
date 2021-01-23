    public class EventViewModel
    {
        public EventViewModel() { }
        public Event EventToEdit { get; set; }
        public SelectList People { get; set; }
        public Guid SelectedPerson { get; set; }
    }
