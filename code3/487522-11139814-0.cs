    // Store the event handlers in private member variables.
    private System.EventHandler listBox1Handler = new System.EventHandler(this.listBox1_SelectedIndexChanged); 
    private System.EventHandler listBox2Handler = new System.EventHandler(this.listBox2_SelectedIndexChanged);
    private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
    { 
        listBox1.SelectedIndexChanged -= listBox1Handler;
    
        // other event handler logic
    
        listBox1.SelectedIndexChanged += listBox1Handler;
    }
