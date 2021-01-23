    protected override IDictionary<string, string> ResourceFiles
    {
        get
        {
            var dictionary = this.GetType()
                .Assembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("ViewModel"))
                .Where(t => !t.Name.StartsWith("Base"))
                .ToDictionary(t => t.Name, t => t.Name);
            dictionary[Constants.Shared] = Constants.Shared;
            foreach (var additional in HelpFileList)
            {
                 dictionary(additional) = additional;
            } 
            return dictionary;
        }
    }  
