    struct UndoRedoItem
    {
        public Func<UndoRedoItem> UndoOrRedoFunc;
        public string Description;
        ... 
    }
