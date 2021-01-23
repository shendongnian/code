    public class CommandAndCallback<TCallback>
    {
        public SqlCommand Sql { get; set; }
        public TCallback Callback { get; set; }
        public ErrorHandler Error { get; set; }
    }
