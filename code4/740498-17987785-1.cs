    static public void CloseForm(Form form)
    {
    	if (form.IsDisposed) {
    		return;
    	}
    
    	if (form.InvokeRequired) {
    		form.Invoke((MethodInvoker)form.Close);
    	}
    	else {
    		form.Close();
    	}
    }
