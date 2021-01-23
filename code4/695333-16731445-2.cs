    public void Add(string itemToAdd)
    {
        items.Add (itemToAdd);
        NotifyDataSetChanged();
    }
