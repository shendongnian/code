    [Association(Storage = "_todos", OtherKey = "_categoryId", ThisKey = "Id")]
    public IEnumerable<ToDoItem> ToDos
    {
        get { return this._todos; }
        set { this._todos.Assign(value); }
    }
