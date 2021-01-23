    public void CountTestHelper<Item>() where Item : IHasRect, new()
     {
        Rectangle rectangle = new Rectangle(0, 0, 100, 100); 
        SomeClass<Item> target = new SomeClass<Item>(rectangle);            
        Point p = new Point(10,10);
        Item i = new Item();    // constructor has to be parameterless!
        ...
     }
