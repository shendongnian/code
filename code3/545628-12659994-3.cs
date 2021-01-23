    private void button_click(object sender, System.EventArgs e)  
    {  
        var btnKey = ((Button)sender).Tag.ToString();  
        if(buttonActions.ContainsKey(btnKey))
            buttonActions[btnKey].Invoke();
    }
