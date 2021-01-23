    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            add();
        }
        //If you are using template field
        ((TemplateField)gvGridView.Columns[index]).EditItemTemplate = null;
        //If you are using boundfield
        ((BoundField)gvGridView.Columns[index]).ReadOnly = true;
    }
 
