    public void TapeMeasure(object sender, EventArgs e) 
    { 
        if (TrussManager.Truss != null) 
        {
            System.Type sysType = sender.GetType();
            if (!(sysType.Name == "ToolStripButton"))
            {
                if (sysType.Name == "ToolStripMenuItem")
                {
                    ToolStripMenuItem temp = (ToolStripMenuItem)sender;
                    if (trussEditor.MainMenu.CommandToolStrip.ClientRectangle.Contains(trussEditor.MainMenu.CommandToolStrip.PointToClient(temp.Owner.Location)))
                    {
                        //execute command A
                    }
                    else
                    {
                        //execute command B
                    }
                }
            }
            else
            {
                //execute command A
            }
        } 
    } 
