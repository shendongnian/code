    var query = DbContext.Set<User>().AsQueryable();
    query = query.Include("Tabs.Boxes");
    query = query.Where(u => u.Name == "test_guy");
    User test_guy = query.Single();
    
    Tab mainTab = new Tab() 
    { 
        TabName = "Main tab",
        Order = 1,
    };
    Tab otherTab = new Tab()
    {
        TabName = "Test Guy's another tab",
        Order = 2
    };
    
    mainTab.Boxes = new Boxes();
    for (int i = 0; i < 10; i++)
    {
        Box box1 = new Box()
        {
            Author = test_guy
        };
        mainTab.Boxes.Add(box1);
    }
    test_guy.Tabs.Add(mainTab);
    test_guy.Tabs.Add(otherTab);
    
    DbContext.SaveChanges();  
