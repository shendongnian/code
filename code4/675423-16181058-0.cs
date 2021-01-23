    class MyRichTextBox : RichTextBox
    {
    	public MyRichTextBox()
    	{
            base.AcceptsTabs = true;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
    	    if(keyData == Keys.Tab)
    	    {
    		    // Do something [editing my post...]
    		    return true;
    	    }
    
    	    return base.ProcessCmdKey(ref msg, keyData);
        }
    }
