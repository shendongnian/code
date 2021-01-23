    public void UpdateLabel(String text){
        if (label.InvokeRequired)
        {
            label.Invoke(new Action<string>(UpdateLabel), text);
            return;
        }      
        label.Text = text;
    }
