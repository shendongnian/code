    
    public interface IUpgradeDomainEvents
    {
        IEnumerable<IDomainEvent> Upgrade(IDomainEvent e, string id);
    }
