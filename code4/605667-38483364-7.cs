    protected bool ValidateStage(object viewModel, int stageToValidate)
    {
    	var propertiesForStage = viewModel.GetType()
    		.GetProperties()
    		.Where(prop => prop.GetCustomAttributes(false).OfType<ValidationStageAttribute>().Any(attr => attr.StageNumber == stageToValidate))
    		.Select(prop => prop.Name);
    
    	return propertiesForStage.All(p => ModelState.IsValidField(p));
    }
