    public TextActionResult Index()
    {
       string resp= GetResponse();
       return new TextActionResult (resp);
    }
