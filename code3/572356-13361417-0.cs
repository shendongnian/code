    private class PriorityQueueEntry<TPriorityValue,IIdentifiableEntry,IType> :
    		IComparer<PriorityQueueEntry<TPriorityValue,IIdentifiableEntry,IType>>
    			where TPriorityValue : IComparable
    			where IIdentifiableEntry : Identifier<IType>
    			where IType : IConvertible
    	{
    		public TPriorityValue Priority{get;private set;}
    		public IIdentifiableEntry Entry{get;private set;}
    		
    		public PriorityQueueEntry(TPriorityValue val,IIdentifiableEntry entry)
    		{
    			Priority = val;
    			Entry = entry;
    		}
    		public int Compare(PriorityQueueEntry<TPriorityValue,IIdentifiableEntry,IType> first, PriorityQueueEntry<TPriorityValue,IIdentifiableEntry,IType> second) 
    		{
    			if (first.Priority.CompareTo(second.Priority) < 0)
    			{
    				return -1;
    			}
    			else if (first.Priority.CompareTo(second.Priority) > 0)
    			{
    				return 1;
    			}
    			return first.Entry.Id.ToUInt32(NumberFormatInfo.CurrentInfo) < first.Entry.Id.ToUInt32(NumberFormatInfo.CurrentInfo) ? -1:1; 
    		}
    	}
