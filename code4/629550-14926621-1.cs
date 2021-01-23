    private Lazy<IGenericRepository<Message>> messageRepository = new Lazy<IGenericRepository<Message>>(new IGenericRepository<Message>()));
    
    public IGenericRepository<Message> MessageRepository
    {
        get
        {
            return messageRepository.Value;
        }
    }
