    var choices = new Dictionary<ChoiceType, Func<ChoiceResult> > (); 
    ...
    
    public ChoiceResult HereWasSwitch(ChoiceType myChoice)
    {
      return choices[myChoice]();
    }
    
