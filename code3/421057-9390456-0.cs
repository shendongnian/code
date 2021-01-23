    Hope this code is helpful for you..
            public void btnSave_Click(object sender, System.EventArgs e)
            {
                 ….
                 PickerEntity pe = (PickerEntity)userPicker.Entities[0];  //Where userPicker is Id of People picker control
                 string username = pe.Description;
                 …
            }
