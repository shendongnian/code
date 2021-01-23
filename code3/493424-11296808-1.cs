    public ActionResult Create(
        SurveyResponseModel surveyresponsemodel) //, int MemberId, int ProgramId)
    {
        // MemberId and ProgramId arguments do not need to be defined
        // They will be picked up my MVC model binder, since there are properties
        // with the same name in SurveyResponseModel class
        //surveyresponsemodel.MemberId = MemberId;
        //surveyresponsemodel.ProgramId = ProgramId;
        surveyresponsemodel.SurveyProgramModel = new SurveyProgramModel(); // new line
        return View(surveyresponsemodel); // <- return your view model here
    } 
