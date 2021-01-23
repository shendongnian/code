    protected void btnSourceConnect_Click(object sender, EventArgs e)
    {
    	SourceString.UserID = txtSourceUN.Text;
    	SourceString.DataSource = txtSourceServer.Text;      
    	SourceString.InitialCatalog = txtSourceDatabase.Text;
    	SourceString.Password = txtSourcePass.Text;   
    
        if (Util.Connection(SourceString, 0))
        {
            lblTesting.Text = "Working!";
        }
        else
        {
            lblTesting.Text = "It No Work";
        }
    }
