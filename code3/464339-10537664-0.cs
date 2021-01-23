    internal void Host(ListView parent, int ID, int index)
    {
        this.ID = ID;
        this.listView = parent;
        if (index != -1)
        {
            this.UpdateStateToListView(index);
        }
    }
