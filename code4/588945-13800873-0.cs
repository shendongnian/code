    public virtual ICollection<ChatMessage> MessagesFrom { get; set; }
    public virtual ICollection<ChatMessage> MessagesTo { get; set; }
    public virtual IEnumerable<ChatMessage> Messages
    {
        get { return MessagesFrom.Concat(MessagesTo); }
    }
