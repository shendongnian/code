    private void Addrecord_Click(object sender, EventArgs e)
    {
       AddRecord();       
    }
    
    private void AddRecord()
    {
        Inputform.ShowDialog();
    
        if(Inputform.Addedrecord)
        {
            Inputform.Addrecord();
            FromControls.CleartheForm(GetControlOnPage())
        }     
    }
    private control GetControlOnPage()
    {
         //logic to return control if needed although it may just be this:  
         return Inputform.groupofcontrols
    }
