    bool ControlIsListed(object sender, MySettingsClass loadedObj)
    {
        foreach (var currentCheckBox in loadedObj.Settings.Where(currentCheckBox => currentCheckBox != null)) 
        {    
            // docTypeAlias is a single string that needs to be matched 
            var docTypeAlias = sender.ContentType.Alias; 
            // This is the current value of currentCheckBox 
            var requiredTypeAlias = currentCheckBox; 
            if (requiredTypeAlias.Equals(docTypeAlias)) return true;
        }
        return false;
    }
