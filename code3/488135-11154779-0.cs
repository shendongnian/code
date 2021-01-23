    public abstract class State<entity_type>
        {
            public abstract void Enter(entity_type obj);
            public abstract void Execute(entity_type obj);
            public abstract void Exit(entity_type obj);
        }
