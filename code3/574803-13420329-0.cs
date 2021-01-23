    void LoadActiveComments(Item item)
    {
        context.Entry(item).Collection(i => i.Comments).Query()
            .Where(c => c.IsActive).Load();
    }
