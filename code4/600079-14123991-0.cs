    public interface IPageableItemContainer
    {
        //Events
        event EventHandler<PageEventArgs> TotalRowCountAvailable;
        // Methods
        void SetPageProperties(int startRowIndex, int maximumRows, bool databind);
        // Properties
        int MaximumRows { get; }
        int StartRowIndex { get; }
    }
