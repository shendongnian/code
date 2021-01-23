    if(Model.CurrentContext.CurrentAccessModifierType & (
         AccessModifierType.Public | AccessModifierType.Static |
         AccessModifierType.Priveleged | AccessModifierType.Private
        ) ==  AccessModifierType.Public)
    {
       ...
    }
