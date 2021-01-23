    int id = Int32.Parse(controllerContext.RouteData.Values["id"].ToString());
    var questionnaire = _proxy.Questionnaires
        .Expand("QuestionGroups")
        .Expand("QuestionGroups/Questions")
        .Where(q => q.Id == id)
        .FirstOrDefault();
    
    var model = Mapper.Map<Questionnaire, QuestionnaireModel>(questionnaire);
    foreach (var group in model.QuestionGroups)
    {
        foreach (var question in group.Questions)
        {
            string inputValueId = "group.question." + question.Id.ToString();
            string value = bindingContext.ValueProvider.GetValue(inputValueId).AttemptedValue;
            question.SubmittedValue = value;
        }
    }
