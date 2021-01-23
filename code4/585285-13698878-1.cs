    public override void Enqueue(object Item)
    {
        base.Enqueue(Item);
        AsyncOp.Post(OnItemAdded, EventArgs.Empty);
    }
