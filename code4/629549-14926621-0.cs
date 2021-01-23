    private IGenericRepository<Message> messageRepository;
    
    public IGenericRepository<Message> MessageRepository
    {
        get
        {
            return messageRepository ?? (messageRepository = new IGenericRepository<Message>());
        }
    }
