    protected void Page_Load(object sender, EventArgs e)
    {
    	if (!IsPostBack) {
    		lblTest.Visible = false;
    	} else {
    		foreach (string ctrl in Request.Form) {
    			Control c = FindControl(ctrl);
    			if (c is Button) {
    				txtRemainder.Visible = c.ID == "btnDiv";
    				return;
    			}
    		}
    	}
    }
