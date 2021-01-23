    protected override void OnInit(EventArgs e) {
        base.OnInit(e);
        mailinglists.DataBinding += bindMyTable;
    }
    protected override void OnLoad(EventArgs e) {
        base.OnLoad(e);
        if (!Page.IsPostBack) {
            DataBind();
        }
    }
    private void bindMyTable(object sender, EventArgs e) {
        // are the conditions set for adding data to the table?
        if (conditionsMet()) {
            myTable.DataSource = getDataSource();
        }
    }
    private IEnumerable<PersonViewModel> getDataSource() {
         List<PersonViewModel> view = new List<PersonViewModel>();
         view.Add(new PersonViewModel(new Person() { Uid = Guid.NewGuid(), Name = "Example", Company = "Co" }));
         return view;
    }
