    public void TapeMeasure(object sender, EventArgs e) 
    { 
        if (TrussManager.Truss != null) 
        {
            System.Type sysType = sender.GetType();
            if (!(sysType.Name == "ToolStripButton"))
                if (sysType.Name == "ToolStripMenuItem")
                {
                    ToolStripMenuItem temp = (ToolStripMenuItem)sender;
                    if (toolStrip1.ClientRectangle.Contains(toolStrip1.PointToClient(temp.Owner.Location)))
                        //execute command A
                    else
                        //execute command B 
                }
                else
                {
                    //execute command B 
                }
        } 
    } 
