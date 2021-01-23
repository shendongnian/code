    enum ChangeState { Inserted, Deleted, Matched }
    struct<T> Annotated { 
        public T Obj; 
        public ChangeState;
    }
