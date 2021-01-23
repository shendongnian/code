    class ViewModel
    {
        public ICommand ShowListSelectorForCounterparties { get; set; }
        public IListSelectorService ListSelector { get; set; }
        public void OnExecuteShowCounterpartySelector()
        {
            this.Counterparty = this.ListSelector.Select<Counterparty>();
        }
    }
