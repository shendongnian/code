    public class ActionResult
    {
        public bool Success { get; set; }
        public List<string> Errors { get; }
        public ActionResult()
        {
            // Initialize whatever you want here
            Errors = new List<string>();
        }
    }
