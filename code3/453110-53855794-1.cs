    public delegate void DiscardingChangesEvent(object sender, DiscardingChangesEventArgs e);
    
    public class DiscardingChangesEventArgs
        {
            public DiscardingChangesOperation Operation { get; set; } = DiscardingChangesOperation.Cancel;
        }
    
    public enum DiscardingChangesOperation
        {
            Save,
            Discard,
            Cancel
        }
