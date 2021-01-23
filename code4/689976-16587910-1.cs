    List<T> backingStructure; //assuming this is what you have.
    //return type chosen to make method name meaningful, up to you to have void
    public UndoRedoObservableCollection<T> From(IEnumerable<T> list)
    {
        backingStructure.Clear();
        foreach(var item in list)
            //populate and return;
    }
