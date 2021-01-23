    public Form1()
    {
        InitializeComponent();
        linkLabel1.MouseEnter += linkLabel_MouseEnter;
        linkLabel2.MouseEnter += linkLabel_MouseEnter;  
    }
    private void linkLabel_MouseEnter(object sender, EventArgs e)
    {
        if (sender is LinkLabel)
        {
            LinkLabel ll = (LinkLabel)sender;
            toolTip1.SetToolTip(ll, ll.Tag.ToString());
            //tag can be any data - use it however you like
            // ie :
            // toolTipPlatypi.SetToolTip(ll,  
            //   DuckbillData.GetPlatypusDataForToolTip(ll.Tag)); 
        }            
    }
