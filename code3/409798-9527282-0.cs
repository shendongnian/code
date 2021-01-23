    public class SymbolGroup : iSymbol
    {
        public SymbolGroup(SymbolGroup Parent, SymRelation Relation)
        {
            Symbols = new List<iSymbol>();
            this.Parent = Parent;
            SymbolRelation = Relation;
            if (SymbolRelation == SymRelation.AND)
                Name = "AND Group";
            else
                Name = "OR Group";
        }
        public int Depth
        {
            get
            {
                foreach (iSymbol s in Symbols)
                {
                    if (s is SymbolGroup)
                    {
                        return (s as SymbolGroup).Depth + 1;
                    }
                }
                return 1;
            }
        }
    }
