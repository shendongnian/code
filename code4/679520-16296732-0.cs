    // Add New Item
    If (Factory.Definitions.CalculationParameters.List().Where(item => item.ID == NewItem.ID).Count == 0)
    {
    // Add new item to list
    Factory.Definitions.CalculationParametersValues.List().Add(NewItem);
    }
    
    // Delete item
    If (Factory.Definitions.CalculationParametersValues.List().Where(item => item.ID == DeleteItem.ID).Count == 0)
    {
    // No record in Values list ... Do something here
    }
    else
    {
    // Some records in Values list .. Do something here
    }
