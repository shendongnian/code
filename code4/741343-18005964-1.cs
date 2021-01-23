    public class ServerResponse
    {
        public string Content { get; set; }
        public ResponseStatus Status { get; set; } // enum
        // use it in first method to determine whether request succeed
        public bool Success 
        {
            get { return (int)Status > 399;
        }
    }
