        public BindingList<TableSet> someTableSets()
        {
            BindingList<TableSet> someTableList = new BindingList<TableSet>();
            foreach (TableSet TS in allTableSets)
                if (TS.IsPopulated == true)
                    someTableList.Add(p);
            return someTableList;
        }
