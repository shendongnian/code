    protected void OnGridItemCommand(object sender, DataGridCommandEventArgs args) {
        if (args.Item.ItemIndex == -1) {
            return;
        }
        // The property mapped to DataKeyField is fetched here
        Guid id = (Guid)datagrid.DataKeys[args.Item.ItemIndex];
        switch (args.CommandName) {
            case "RemoveRow": {
               // use id to find the actual item in the datasource
            }
            break;
        }
    }
    private void bindDataGrid(object sender, EventArgs e) {
        List<ItemViewModel> source = new List<ItemViewModel>();
        source.Add(new ItemViewModel("hello"));
        datagrid.DataSource = source;
    }
    class ItemViewModel {
        private Guid id;
        public ItemViewModel(string name) {
            id = Guid.NewGuid();
            Name = name;
        }
        public Guid Id { get { return id; } }
        public string Name { get; private set; }
    }
