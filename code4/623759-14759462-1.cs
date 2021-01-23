    public Item ReturnCopy()
    {
        Item newItem = new Item();
        
        newItem._id = _id;
        newItem._order = _order;
        newItem._name = _name;
        return newItem
    }
