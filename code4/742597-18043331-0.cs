    Dictionary<string, Action> actionDict = new Dictionary<string, Action>();
                               
    
    private void button_Click(object sender, EventArgs e)
    {
        Button B = (Button)sender;
        if(B != null)
        {
            Action methodToCall = null;
            if (actionDict.TryGetValue(B.Name, out methodToCall))
            {
                methodToCall();
            } 
        }
    }
