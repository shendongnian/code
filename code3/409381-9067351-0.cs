    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
    	foreach (Control ctrl in this.Panel1.Controls)
    	{
    		Form ctrlAsForm = ctrl as Form;
    		if (ctrlAsForm != null)
    		{
    			ctrlAsForm.Close();
    		}
    	}
    }
