    public ActionResult Index()
    {
        // pretend this is your base proxy object
        One oneProxy = new One { OneId = 1 };
        // add a few collection items
        oneProxy.Two.Add(new Two() { OneId = 1, TwoId = 1 });
        oneProxy.Two.Add(new Two() { OneId = 1, TwoId = 2 });
        // create a mapping (this should go in either global.asax 
        // or in an app_start class)
        AutoMapper.Mapper.CreateMap<One, OnePoco>();
        AutoMapper.Mapper.CreateMap<Two, TwoPoco>();
        // do the mapping- bingo, check out the asjson now
        // i.e. oneMapped.AsJson
        var oneMappped = AutoMapper.Mapper.Map<One, OnePoco>(oneProxy);
        return View(oneMappped);
    }
