    public void Order(IndexOrdering ordering)
    {
        switch (ordering)
        {
            case IndexOrdering.FirstToLast:
                _items.Sort(new AscendingComparer());
                break;
            case IndexOrdering.LastToFirst:
                _items.Sort(new DescendingComparer());
                break;
            case IndexOrdering.Random:
                _items.Sort(new RandomComparer());
                break;
            default:
                throw new ArgumentOutOfRangeException("ordering");
        }
    }
