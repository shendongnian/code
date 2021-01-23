    public interface IRepositoryBehavior
    {
        void OnAdding(CancellableBehaviorContext context);
        void OnAdd(BehaviorContext context);
    
        void OnGetting(CancellableBehaviorContext context);
        void OnGet(BehaviorContext context);
    
        void OnRemoving(CancellableBehaviorContext context);
        void OnRemove(BehaviorContext context);
    
        void OnFinding(CancellableBehaviorContext context);
        void OnFind(BehaviorContext context);
    
        bool AppliesToEntityType(Type entityType);
    }
