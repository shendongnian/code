    private void panel3_VisibleChanged(object sender, EventArgs e)  
    {  
    if (panel3.Visible == false)  
    {  
    if (panel3.Tag == null)  
    panel3.Tag = panel3.Height;  
    panel2.Height += (int)panel3.Tag;  
    }  
    else 
    {  
    if (panel3.Tag == null)  
    panel3.Tag = panel3.Height;  
    panel2.Height -= (int)panel3.Tag;  
    }  
    }  
