    public ActionResult Index()
    {
        // pretend this is your base proxy object
        var oneTest = new One { OneId = 1 };
        // add a few collection items
        oneTest.Two.Add(new Two() { OneId = 1, TwoId = 1 });
        oneTest.Two.Add(new Two() { OneId = 1, TwoId = 2 });
        // create the mapped object container
        //var oneMap = new OnePoco();
        // create a mapping (this should go in either global.asax 
        // or in an app_start class)
        AutoMapper.Mapper.CreateMap<One, OnePoco>();
        AutoMapper.Mapper.CreateMap<Two, TwoPoco>();
        // do the mapping- bingo, check out the asjson now
        // i.e. oneMap.AsJson
        var oneMap = AutoMapper.Mapper.Map<One, OnePoco>(oneTest);
        return View(oneMap);
    }
