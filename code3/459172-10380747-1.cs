      private void Button1_Click(object sender, EventArgs e)
    {
    	Thread t1 = new Thread(StartMe);
    	t1.Name = "Custom Thread";
    	t1.IsBackground = true;
    	t1.Start();
    }
    
    private void StartMe()
    {
    	//We are switching to main UI thread.
    	TextBox1.Invoke(new InvokeDelegate(InvokeMethod), null); 
    }
    
    public void InvokeMethod()
    {
    	//This function will be on main thread if called by Control.Invoke/Control.BeginInvoke
    	MyForm frm = new MyForm();
    	frm.Show();
    }
