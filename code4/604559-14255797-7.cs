    private readonly ICodeCommandHandler commandHandler;
    public CodeController(ICodeCommandHandler commandHandler)
    {
        this.commandHandler = commandHandler;
    }
    [HttpPost]
    public ActionResult Create(CodeTagViewModel codeTagViewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(codeTagViewModel);
        }
        var id = codeCommandHandler.Save(codeTagViewModel);
        // maybe do something useful with the document id after save
        return RedirectToAction("Index");  
    }
