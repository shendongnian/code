    Dictionary<string, Action> actionDict = new Dictionary<string, Action>();
                              {
                                 { "START", optionStart},
                                 { "LOAD", optionLoad},
                                 { "EXIT1", () => { Application.Exit(); }},
                                 { "EXIT2", backToMainMenu }
                              };
    
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
