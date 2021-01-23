    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!Page.IsPostBack) {
            // on postback the grid is created thanks to the viewstate
            // that's why we don't bind it
            gridview.DataBind();
        }
    }
    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        gridview.DataBinding += bindGridView;
    }
    protected void OnGridRowCommand(object sender, GridViewCommandEventArgs args) {
        // The commandargument is set on the button, so a unique index for an item
        // should be used to identify it from the db.
        // in this case, commandargument is a string (not an int) so parse it
        int index = Int32.Parse((string)args.CommandArgument);
        switch (args.CommandName) {
            case "RemoveRow": {
                    // remember, gridview.DataSource can be null here
                    // so act on the database directly
                    getSource().RemoveAt(index);
                    gridview.DataBind();
                }
                break;
        }
    }
    private void bindGridView(object sender, EventArgs e) {
        // set the source from the database
        gridview.DataSource = getSource();
    }
    // this represents the db
    private List<ItemViewModel> source;
    private IList<ItemViewModel> getSource() {
        if (source == null) {
            source = new List<ItemViewModel>();
            source.Add(new ItemViewModel("Karl"));
            source.Add(new ItemViewModel("Urban"));
            source.Add(new ItemViewModel("Bill"));
        }
        return source;
    }
    class ItemViewModel {
        private Guid id;
        public ItemViewModel(string name) {
            id = Guid.NewGuid();
            FirstName = name;
        }
        public Guid Id { get { return id; } }
        public string FirstName { get; private set; }
    }
