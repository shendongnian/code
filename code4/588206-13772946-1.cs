    protected void btnCheck_Click(object sender, EventArgs e)
    {
    	lblYesNo.Text = "";
    	//default int values are set to 0
    	int remainder = 0;
    	int guess = 0;
    	
    	if (!Int32.TryParse(txtRemainder.Text, out remainder))
    	{
    		// do something here to inform the user that remainder is invalid
    		return;
    	}
    	
    	if (!Int32.TryParse(txtAnswer.Text, out remainder))
    	{
    		// do something here to inform the user that answer is invalid
    		return;
    	}
    	
    	answer = (int)Session["answer"];
    	if (guess > answer)
    	{
    		lblYesNo.Text = lblYesNo.Text + "Try Again..";
    	}
    	else if (guess < answer)
    	{
    		lblYesNo.Text = lblYesNo.Text + "Try Again..";
    	}
    	else
    	{
    		lblYesNo.Text = lblYesNo.Text + "Correct!";
    	}
    }//END Check Answer
