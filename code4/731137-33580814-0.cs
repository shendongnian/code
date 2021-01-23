    public async Task<ActionResult> Index()
    {
        var dal = new DalAsync();
        var assignedCases = Task.Run(async () => await dal.GetAssignedCasesAsync());
        var newCases = Task.Run(async () => await dal.GetNewCasesAsync());
        var allCases = await Task.WhenAll( assignedCases, newCases).ConfigureAwait(false);
        return View( "Cases", allCases.SelectMany( c => c ) );
    }
