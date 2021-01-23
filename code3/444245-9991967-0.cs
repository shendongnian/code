    public ConfigElementDoesNotExistException(string sectionName, 
                                              string elementName, 
                                              string errorMessage = null, 
                                              Exception innerEx = null)   
    : base(errorMessage ?? string.Format("The section {0} doesn't ... {1}", 
                           sectionName ?? "[unknown]", elementName ?? "[unknown]")
           , innerEx)   
    {   
      _sectionName = sectionName;   
      _elementName = elementName;   
    }   
