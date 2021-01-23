    public class SomeObject
    {
    	public Version Version { get; set; }
    	public string Description { get; set; }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
    	var ls = new List<SomeObject>()
    			                {
    			                    new SomeObject() {Description = "Test", Version = new Version(1, 1)},
    			                    new SomeObject() {Description = "Test2", Version = new Version(2, 1)}
    			                };
    	gv.DataSource = ls;
    	gv.DataBind();
    }
