    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            var hyperlinkField = new TemplateField();
            hyperlinkField.ItemTemplate = new HyperlinkColumn();
            tableResults.Columns.Add(linkField);
        }
    }
    class HyperlinkColumn : ITemplate
    {
    	public void InstantiateIn(System.Web.UI.Control container)
    	{
    		HyperLink hypLink = new HyperLink()
    		container.Controls.Add(link);
    	}
    }
