    public class RoomList : List<Event[]>
    {
        public IEnumerable<Event> Column(int columnIndex)
        {
            foreach (Event[] events in this) {
                if (events != null && columnIndex < events.Length) {
                    yield return events[columnIndex];
                }
            }
        }
    }
