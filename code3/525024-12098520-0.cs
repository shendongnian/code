    protected void Page_Load(object sender, EventArgs e)
    {
        Image tmp1 = new Image();
        Image tmp2 = new Image();
    
        tmp1.Width = new Unit(500);
        tmp2.Width = new Unit(1000);
    
        Response.Write(((Unit)tmp1.Width).Value < ((Unit)tmp2.Width).Value);
    }
