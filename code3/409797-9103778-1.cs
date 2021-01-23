        public List<List<Symbol>> ReduceList(List<iSymbol> List)
        {
            List<List<Symbol>> Output = new List<List<Symbol>>(List.Count);
            foreach (iSymbol iSym in List)
            {
                if (iSym is Symbol_Group)
                {
                    List<Symbol> L = new List<Symbol>();
                    (iSym as Symbol_Group).GetAllSymbols(L);
                    Output.Add(L);
                }
                else
                {
                    throw (new Exception());
                }
            }
            return Output;
        }
        public void GetAllSymbols(List<Symbol> List)
        {
            foreach (List<iSymbol> SubList in Symbols)
            {
                foreach (iSymbol iSym in SubList)
                {
                    if (iSym is Symbol)
                    {
                        List.Add(iSym as Symbol);
                    }
                    else if (iSym is Symbol_Group)
                    {
                        (iSym as Symbol_Group).GetAllSymbols(List);
                    }
                    else
                    {
                        throw(new Exception());
                    }
                }
            }
        }
