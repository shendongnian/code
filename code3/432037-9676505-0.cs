    public abstract class PostEvent<TPost> : IDomainEvent
        where TPost : Post, new()
    {
        public abstract void SomeInterfaceMethod();
    }
