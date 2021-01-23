    public interface ICustomSorter : IComparer
    {
	    ListSortDirection SortDirection { get; set; }
    
        string SortMemberPath { get; set; }
    }
