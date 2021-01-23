    private static SGMemberDataOp sgMemberDataOp;
    
     public static SGMemberDataOp SGMemberDataOp
     {
        get { return sgMemberDataOp; }
     }
    public App()
    {
        try
        {
            sgMemberDataOp = new SGMemberDataOp();
        }
        catch (Exception Ex)
        {
            MessageBox.Show(Ex.Message, "Startup failed", MessageBoxButton.OK);
        }
    }
