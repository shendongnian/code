    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        { 
            var linkField = new TemplateField();
            linkField.ItemTemplate = new LinkColumn();
            GridView1.Columns.Add(linkField);
        }
    }
    class LinkColumn : ITemplate
    {
    	public void InstantiateIn(System.Web.UI.Control container)
    	{
    		LinkButton link = new LinkButton();
    		link.ID = "linkmodel";
    		container.Controls.Add(link);
    	}
    }
