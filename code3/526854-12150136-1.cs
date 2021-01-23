    for (int i = 0; i <= amt.Count(); i++)  
    {  
        Control[] t = Controls.Find("amtBox" + i, false);
        if(t != null && t.Length > 0)
        {
            amt[i] = int.Parse(t[0].Text);  
        }
    } 
