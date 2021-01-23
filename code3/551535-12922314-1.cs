    public Form1( )
    {
         InitializeComponent( );
         ToolStripSimpleUserControl suc = new ToolStripSimpleUserControl( );
         suc.StripSimpleUserControl.Size = new Size( 30, 20 );
         
         statusStrip1.Items.Add(suc);
    }
