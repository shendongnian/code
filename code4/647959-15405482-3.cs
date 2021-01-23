    IInitializable [] parts = new IInitializable [7];
    parts[0] = new WindShield();
    ...
    parts[6] = new Wheel();
    
    parts[3].Initialize(new Vector2(0, 0));
