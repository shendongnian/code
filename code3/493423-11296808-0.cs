    public ActionResult Create(
        SurveyResponseModel surveyresponsemodel, int MemberId, int ProgramId)
        {
            surveyresponsemodel.MemberId = MemberId;
            surveyresponsemodel.ProgramId = ProgramId;
            return View(surveyresponsemodel); // <- return your view model here
        } 
