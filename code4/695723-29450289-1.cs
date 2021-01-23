    public abstract class IGroup<T> : IEnumerable where T : class {
    
        protected List<T> groupMembers;
        protected List<IGameAction> groupIGameActionList;
    
        public IGroup() {
            groupMembers = new List<T>();
    
            groupIGameActionList = new List<IGameAction>();
            groupIGameActionList.Add(new DieGameAction(new ObjectListAdapter<T>(groupMembers)));
        }
    }
