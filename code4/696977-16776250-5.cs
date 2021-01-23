    public SymbolStatsModel SymbolStatsModel
    {
        get
        {
            return new SymbolStatsModel(Symbol);
        }
        set
        { 
            this.Symbol = value.Symbol;
        }
    }
