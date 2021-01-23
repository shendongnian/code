        public class Event
        {
            public DateTime Timestamp { get; set; }
        }
        private IObservable<Event> eventStream1;
        private IObservable<Event> eventStream2; 
        public IObservable<IEnumerable<Event>> CombineAndGroup()
        {
            return eventStream1.CombineLatest(eventStream2, (e1, e2) => e1.Timestamp < e2.Timestamp ? e1 : e2)
                .ToEnumerableUntilChanged(e => e.Timestamp);
        }
