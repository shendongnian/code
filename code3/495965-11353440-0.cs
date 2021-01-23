    private void Form1_Load(object sender, EventArgs e)
    {
    	Random random = new Random();
    	foreach (Control c in this.Controls)
    	{
    		if(c.GetType().Name == "TextBox")
    		{
    			c.Text = random.Next().ToString();
    		}
    	}
    }
