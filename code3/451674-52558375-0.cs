    private readonly IMyEntityRepository myEntityRepo; // depends on MyDbContext
    private readonly IFooRepository fooRepo; // depends on MyDbContext
    private readonly IBarRepository barRepo; // depends on MyDbContext
    public MyController(
        IMyEntityRepository myEntityRepo, 
        IFooRepository fooRepo, 
        IBarRepository barRepo)
    {
        this.fooRepo = fooRepo;
        this.barRepo = barRepo;
        this.myEntityRepo = myEntityRepo;
    }
