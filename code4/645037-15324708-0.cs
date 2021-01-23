    private bool insideTitleBar = false;
    private bool outsideTitleBar = false;
    
    protected override void WndProc(ref Message m)
    {
        if (m.Msg == 0xA0) // WM_NCMOUSEMOVE
        {        
               if(!insideTitleBar)
               {
                listBox1.Items.Add("mouse move on title bar");
                insideTitleBar = true;
                outsideTitleBar = false;
               }
        } 
        else if (m.Msg == 0x2A2) // WM_NCMOUSELEAVE
        {
               if(!outsideTitleBar)
               {      
                listBox1.Items.Add("mouse leave from title bar");            
                outsideTitleBar = true;
                insideTitleBar = false;
               }
        }
        base.WndProc(ref m);
    }
