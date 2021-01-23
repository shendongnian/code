    public BranchWizardStep GetNextStep(FormCollection formCollection)
    {
        TryUpdateModel(_someModel);
    
        if (ModelState.IsValid) 
        {
            //...
        }
    }
