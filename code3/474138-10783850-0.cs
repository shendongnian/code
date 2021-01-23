    public bool CtrlPressed=false;
    void Control_KeyUp(object sender, KeyEventArgs e)
    {          
        if (e.KeyCode == Keys.C && ctrlPressed == true )
        {
            CopyToClipboard(dgDS408Parameter.CurrentCell.EditedFormattedValue.ToString());                           
        }
        CtrlPressed=false;
    }   
    
    void Control_KeyDown(object sender, KeyEventArgs e)
    {          
        if (e.Control == true )
        {
            CtrlPressed=true;
        }
    }
