    this.Init += Page_Init;
    this.Load += Page_Load;
    protected void Page_Init(object sender, System.EventArgs e)
    {
    		createControls();
    	}
    
    	protected void Page_Load(object sender, System.EventArgs e)
    	{
    		if (IsPostBack)
    		{
    			setcontrolvalues();
    		}
    	}
    
    	private void createControls()
    	{
    		TextBox txt1 = new TextBox();
    		TextBox txt2 = new TextBox();
    		txt1.ID = "txt1";
    		txt1.EnableViewState = true;
    		txt2.EnableViewState = true;
    		txt2.ID = "txt2";
    		PlaceHolder1.Controls.Add(txt1);
    		PlaceHolder1.Controls.Add(txt2);
    	}
    
    	private void setcontrolvalues()
    	{
    		TextBox txt1 = null;
    		TextBox txt2 = null;
    		txt1 = (TextBox)(PlaceHolder1.FindControl("txt1"));
    		txt1.Text = "text1";
    		txt2 = (TextBox)(PlaceHolder1.FindControl("txt2"));
    		txt2.Text = "text2";
