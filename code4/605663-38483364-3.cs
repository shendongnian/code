    protected bool ValidateStage(object model, int stageToValidate)
    {
    	var propertiesForStage = postedModel.GetType()
    		.GetProperties()
    		.Where(prop => prop.GetCustomAttributes(false).OfType<ValidationStageAttribute>().Where(attr => attr.StageNumber == stageToValidate));
    		.Select(prop => prop.Name);
    
    	return propertiesForStage.All(p => ModelStage.IsValidField(p));
    }
