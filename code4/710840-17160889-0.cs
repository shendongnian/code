    class QueueItem
    {
        public Func<object> FuncToExecute { get; set; }
        public Action OptionalCallback { get; set; }
    }
