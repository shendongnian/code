    public void btnSave_Click(object sender, System.EventArgs e)
    {
       ….
       //where userPicker is Id of People picker control
       PickerEntity pe = (PickerEntity)userPicker.Entities[0];  
       string username = pe.Description;
       …
    }
