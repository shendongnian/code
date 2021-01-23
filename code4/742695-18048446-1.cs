    if(delta < 0) 
    {
        for(int i = -delta; i > 0; i--)
        {
            var tbox = Controls.Find("ntextBox" + i, false);
            Controls.Remove(tbox);
        }
    }
    else if(delta > 0) 
    {
        for(int i = 0; i < delta; i++) 
        {
            var tbox = new TextBox();
            //other textbox code
            tbox.Name = "ntextBox" + i;
            Controls.Add(tbox);
        }
    }
