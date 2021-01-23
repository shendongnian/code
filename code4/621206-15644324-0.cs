    private readonly IMyRepository myRepository;
    
    public MyController(IMyRepository myRepository)
    {
         this.myRepository = myRepository;
    }
    
    public ActionResult Details(int id)
    {
         MyObject myObject = myRepository.FindById(id);
    
         return View();
    }
