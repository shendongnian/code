    //Form Start
    
    void MainFormLoad(object sender, EventArgs e)
    {
    
        Control.ControlCollection locais =  groupBoxLocalização.Controls;
    
            foreach (CheckBox chkBox in locais)
            {
                chkBox.MouseUp += chkBoxLocais_MouseUp;
    	    }
    }
    
    // Event
    void chkBoxLocais_MouseUp(object sender, MouseEventArgs e)
    {
    
        //Tratar individualmente
        CheckBox chk = (CheckBox)sender;
    
        //ou para tratar todos objetos de uma vez
         
    	Control.ControlCollection locais =  groupBoxLocalização.Controls;
    	foreach (CheckBox chkBox in locais) {
            //chkBox....
        }
    
    }
