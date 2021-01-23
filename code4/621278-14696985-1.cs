    public void CountTestHelper<Item>() where Item : IHasRect
    {
        Rectangle rectangle = new Rectangle(0, 0, 100, 100); 
        SomeClass<Item> target = new SomeClass<Item>(rectangle);            
        Point p = new Point(10,10);
        SomeNamespace.Item i = new SomeNamespace.Item(p, 10);  
    }
