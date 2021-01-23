    public delegate void OnInvalidEntryMethod(ITnEntry entry, string message);
    public class EntryValidator
    {
        public event OnInvalidEntryMethod OnInvalidEntry;
        public bool IsValidEntry(ITnEntry entry, string ticker)
        {
            if (!IsFieldValid(entry, ticker.Trim().Length.ToString(), "0"))
                return false;
            return true;
        }
        private bool IsFieldValid(ITnEntry entry, string actual, string invalidValue)
        {
            if (actual == invalidValue)
            {
                RaiseInvalidEntryEvent(entry);
                return false;
            }
            return true;
        }
        public virtual void RaiseInvalidEntryEvent(ITnEntry entry)
        {
            if (OnInvalidEntry != null)
                OnInvalidEntry(entry, "Invalid entry in list: " + entry.List.Name + ".");
        }
    }
    // Had to reverse engineer the following since they were not available in the question
    public interface ITnEntry
    {
        Ticket List { get; set; }
        string Ticker { get; set; }
    }
    public class TnEntry : ITnEntry
    {
        public Ticket List { get; set; }
        public string Ticker { get; set; }
    }
    public class Ticket
    {
        public string Name { get; set; }
    }
