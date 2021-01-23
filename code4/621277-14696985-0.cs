    public void CountTestHelper<TItem>() where TItem : IHasRect
    {
        Rectangle rectangle = new Rectangle(0, 0, 100, 100); 
        SomeClass<TItem> target = new SomeClass<TItem>(rectangle);            
        Point p = new Point(10,10);
        Item i = new Item(p, 10);    
        ...
    }
