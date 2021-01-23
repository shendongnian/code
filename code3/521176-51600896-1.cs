    var ac = (ReportPre)Application.OpenForms["ReportPre"];
    Thread shower = new Thread(new ThreadStart(() =>
    	{
    		if (ac == null)
    		{				 
    			this.Invoke((MethodInvoker)delegate () {
    				ac = new ReportPre();
    				ac.Show();
    			});       
    		}
    		else
    		{
    			this.Invoke((MethodInvoker)delegate
    			{
    				pictureBox1.Visible = true;
    			});
    			if (ac.InvokeRequired)
    			{
    				ac.Invoke(new MethodInvoker(delegate {
    					ac.Hide();
    					ac.Show();
    				}));                          
    			}
    		}
    	}));
    shower.Start();
