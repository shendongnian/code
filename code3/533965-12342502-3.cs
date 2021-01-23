    protected void btnEnter_Click(object sender, EventArgs e)
    {
        Button btn = (Button)sender;
         // the btn.Text keeps the number of post backs (enters of name).
        var Counter = Int32.Parse(btn.Text);
        Counter++;
        if(Counter >= 5)
        {   
        	Label1.Text = "No more studen's names please";
        }
        else
        {    
    		btn.Text = Counter.ToString();    		
    		Label1.Text = "Enter Another student's name";
    	}
    }
