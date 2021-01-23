    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            PostComments_global1.varriable1= 6; //PostComments_global1 is your webuseruser controll id
            PostComments_global1.varriable2= 6;
        }
    }
