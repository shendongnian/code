    private void Addrecord_Click(object sender, EventArgs e)
    {
       AddRecord();       
    }
    
    private void AddRecord()
    {
        Inputform.ShowDialog();
    
        if(Inputform.Addedrecord == true)
        {
            Inputform.Addrecord();
            FromControls.CleartheForm(GetControlsOnPage())
            label3.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
        }     
    }
    private control GetControlsOnPage()
    {
         //logic to return control if needed although it may just be this:  
         return Inputform.groupofcontrols
    }
