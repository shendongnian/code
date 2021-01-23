        public List<iSymbol> GetInvertedGroup()
        {
            TrimSymbolList();
            List<List<iSymbol>> symbols = this.CopyListMembers(Symbols);
            List<iSymbol> SymList;
            while (symbols.Count > 1)
            {
                symbols.Add(MultiplyLists(symbols[0], symbols[1]));
                symbols.RemoveRange(0, 2);
            }
            SymList = symbols[0];
            for(int i=0;i<symbols[0].Count;i++)
            {
                if (SymList[i] is Symbol)
                {
                    Symbol sym = SymList[i] as Symbol;
                    SymList.RemoveAt(i--);
                    Symbol_Group symgrp = new Symbol_Group(null);
                    symgrp.AddSymbol(sym);
                    SymList.Add(symgrp);
                }
            }
            for (int i = 0; i < SymList.Count; i++)
            {
                if (SymList[i] is Symbol_Group)
                {
                    Symbol_Group SymGrp = SymList[i] as Symbol_Group;
                    if (SymGrp.Symbols.Count > 1)
                    {
                        List<iSymbol> list = SymGrp.GetInvertedGroup();
                        SymList.RemoveAt(i--);
                        AddElementsOf(list, SymList);
                    }
                }
            }
            return SymList;
        }
        public List<iSymbol> MultiplyLists(List<iSymbol> L1, List<iSymbol> L2)
        {
            List<iSymbol> Combined = new List<iSymbol>(L1.Count + L2.Count);
            foreach (iSymbol S1 in L1)
            {
                foreach (iSymbol S2 in L2)
                {
                    Symbol_Group newGrp = new Symbol_Group(null);
                    newGrp.AddSymbol(S1);
                    newGrp.AddSymbol(S2);
                    Combined.Add(newGrp);
                }
            }
            return Combined;
        }
