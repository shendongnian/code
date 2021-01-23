    private void button1_Click(object sender, EventArgs e)
    {
    	using (ModalForm1 frm = new ModalForm1(myParam))
    	{
    		frm.ShowDialog();
    		
    		if (frm.MyResultProperty == ...)
    		{
    			// Do some job here
    		}
    	}
    }
