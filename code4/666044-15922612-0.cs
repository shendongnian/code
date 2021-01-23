    public void NotifyMe(string s, string s2, string s3, string s4, string s5)
    {
	    if (textBox1.InvokeRequired)
	    {
	    	textBox1.Invoke((MethodInvoker)delegate { textBox1.Text = s; });
	    }
	    else
	    {
	    	textBox1.Text = s;
	    }
        //...
    }
