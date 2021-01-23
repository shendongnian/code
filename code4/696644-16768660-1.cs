    public partial class UC1 : System.Web.UI.UserControl
    {
    	public IEnumerable<ListItem> DDLData;
    
    	protected void Page_Load(object sender, EventArgs e)
    	{
    	}
    	public override void DataBind()
    	{
    		ddl.DataSource = DDLData;
    		ddl.DataBind();
    		base.DataBind();
    	}
    }
