    static bool insertPressed;
    static bool tabPressed;
        
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
    	if(keyData == Keys.Tab)
    	{
    		tabPressed = true;
    		CheckForTabAndInsert();
    	}
    	return base.ProcessCmdKey(ref msg, keyData);
    }
    
    static void form_KeyDown(object sender, KeyEventArgs e)
    {
    	if (e.KeyCode == Keys.Insert)
    	{
    		insertPressed = true;
    		CheckForTabAndInsert();
    		insertPressed = false;
    	}
    }
        
    static void form_KeyUp(object sender, KeyEventArgs e)
    {
    	if (e.KeyCode == Keys.Insert) insertPressed = false;
    }
