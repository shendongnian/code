    partial class Event :IMethods<Event>
    {
        public IEnumerable<Event> ActiveItems()
        {
            try
            {
                using (var db = new Entities())
                {
                    DateTime now = DateTime.Today;
                    return db.Events.Where(b => !b.removed && b.start_date <= now && b.end_date >= now);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
