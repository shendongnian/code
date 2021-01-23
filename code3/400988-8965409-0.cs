    GameOfThronesContext context = new GameOfThronesContext();
    Throne t = new Throne();
    King k = new King();
    //t.Kings.Add(k);  // doesn't work because "Add" isn't available
    k.Throne = t;  // this is made available by the framework
    context.Thrones.AddObject(t);
