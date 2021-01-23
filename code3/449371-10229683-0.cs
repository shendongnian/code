    public event System.EventHandler SelectedIndexChanged;
    public event System.EventHandler SelectionChangeCommitted;
    public int SelectedIndex {
        get;
        set;
    }
    public T SelectedItem { // Where T is whatever your type is
        get;
        set;
    }
