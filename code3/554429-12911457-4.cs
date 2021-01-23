    [GridAction(EnableCustomBinding = true)]
    public JsonResult UpdateNational(NationalViewModel Model, GridCommand Command)
    {
         if (!ModelState.IsValid)
            return new JsonResult { Data = "error" };
        var part = _contentmanager.Get(Model.Id).As<NationalPart>();
        part.Record.MapFrom<NationalPartRecord, NationalViewModel>(Model);        
        return NationalsListJson(Command);
    }
