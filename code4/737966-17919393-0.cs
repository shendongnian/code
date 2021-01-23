    class MessageItem
    {
        private readonly List<MessageItem> children = new List<MessageItem>();
        public List<MessageItem> Children { get { return children; } }
        public int MessageId { get; set; }
        public int ReplyMessageId { get; set; }
        public DateTime PostedDate { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return string.Format("{0} ({1}): {2}", MessageId, ReplyMessageId, Message);
        }
    }
    static void Main()
    {
        // input data
        var cu = CultureInfo.InvariantCulture;
        var data = new[] {
            new MessageItem{ MessageId = 66, ReplyMessageId = 65, Message = "Hello", PostedDate = DateTime.Parse("6/25/2013 10:00:01 AM", cu)},
            new MessageItem{ MessageId = 68, ReplyMessageId = 66, Message = "[Reply to Hello]-1", PostedDate = DateTime.Parse("6/25/2013 10:12:23 AM",cu)},
            new MessageItem{ MessageId = 72, ReplyMessageId = 66, Message = "[Reply to Hello]-2", PostedDate = DateTime.Parse("6/25/2013 11:12:23 AM",cu)},
            new MessageItem{ MessageId = 73, ReplyMessageId = 66, Message = "[Reply to Hello]-3", PostedDate = DateTime.Parse("6/26/2013 9:12:23 AM",cu)},
            new MessageItem{ MessageId = 74, ReplyMessageId = 66, Message = "[Reply to Hello]-4", PostedDate = DateTime.Parse("6/25/2013 11:12:12 PM",cu)},
            new MessageItem{ MessageId = 75, ReplyMessageId = 68, Message = "[Reply to Hello-1] -1", PostedDate = DateTime.Parse("6/25/2013 11:05:12 AM",cu)},
            new MessageItem{ MessageId = 76, ReplyMessageId = 73, Message = "[Reply to Hello-3] -1", PostedDate = DateTime.Parse("6/26/2013 10:10:23 AM",cu)},
            new MessageItem{ MessageId = 80, ReplyMessageId = 75, Message = "[Reply to Hello-1-1] -1", PostedDate = DateTime.Parse("6/25/2013 11:45:22 AM",cu)},
            new MessageItem{ MessageId = 81, ReplyMessageId = 68, Message = "[Reply to Hello-1]-1", PostedDate = DateTime.Parse("6/25/2013 11:45:22 AM",cu)},
        };
        
        // build the hierarchy, using a parent lookup
        var ids = data.ToDictionary(x => x.MessageId);
        List<MessageItem> orphans = new List<MessageItem>();
        foreach (var item in data)
        {
            MessageItem parent;
            (ids.TryGetValue(item.ReplyMessageId, out parent) ? parent.Children : orphans).Add(item);
        }
        // write the hierarchy using a stack (to avoid recursion)
        Stack<MessageItem> pending = new Stack<MessageItem>();
        // the following looks backwards, but isn't (the stack reverses the order)
        // personally, I would use => x.PostedDate, but that gives a different order
        // (the *correct* order, IMO); this gives the *requested* order; no point
        // ordering *after* MessageId, as presumably that is unique
        foreach (var msg in orphans.OrderBy(x => x.MessageId)) pending.Push(msg); 
        while (pending.Count > 0)
        {
            var next = pending.Pop();
            Console.WriteLine(next);
            foreach (var msg in next.Children.OrderBy(x => x.MessageId)) pending.Push(msg);
        }
    }
