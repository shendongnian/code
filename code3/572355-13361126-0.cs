        public TPriorityValue Priority{get;private set;}
        public TEntry Entry{get;private set;}
        public PriorityQueueEntry(TPriorityValue val, TIdentifiableEntry entry)
        {
            Priority = val;
            Entry = entry;
        }
        public int Compare(PriorityQueueEntry<TPriorityValue, TEntry first, PriorityQueueEntry<TPriorityValue, TEntry> second) 
        {
            if (first.Priority.CompareTo(second.Priority) < 0)
            {
                return -1;
            }
            else if (first.Priority.CompareTo(second.Priority) > 0)
            {
                return 1;
            }
            return first.Enrtry.CompareTo(second.Entry);
        }
    }
