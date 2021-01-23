    internal class NameSpaceExpansionFunction : ExpansionFunction
        {
            public NameSpaceExpansionFunction(ExpansionProvider provider)
                : base(provider)
            {
            }
    
            public override string GetCurrentValue()
            {
               //get namespace
               return namespace
            }
        }
