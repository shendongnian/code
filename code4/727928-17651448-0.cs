    sealed class ItemWrapper
    {
        AnAbstractClass Item { get; set; }
        Metadata Metadata { get; set; }
        ItemWrapper(AnAbstractClass item, Metadata metadata) 
        {
            Item = item;
            Metadata = metadata;
        }
    }
