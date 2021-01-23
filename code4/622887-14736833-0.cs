    public void ApplyNextColor(params Control[] controls)
    {
        Color nextColor = colors.Dequeue();
        colors.Enqueue(nextColor);//add to end so that we cycle; 
        //you can optionally remove and do nothing if there are not items.
    
        foreach (Control control in controls)
            control.BackColor = nextColor;
    }
