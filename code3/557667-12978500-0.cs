    FormTemplate formTemplate = PolicyClassCollection.CachedPolicyClasses
        .FindBy((int)EnumPolicyClasses.PNI).FormTemplateCollection
        .Find(ft => ft.PolicyClassId == Utility.GetCurrentPolicyClassId() 
        && ft.DocumentType.DocumentTypeId == (int)EnumDocumentTypes.Coverage_Summary
        && ft.PolicyTypeId == Utility.GetCurrentAccount().CurrentRisk.PolicyTypeId);
