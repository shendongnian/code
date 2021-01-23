    public void CheckBox_CheckChanged(object sender, EventArgs e){
       CheckBox.Enabled = false;
       Cursor = Cursors.Wait;
       //Long Running database operation
       Cursor = Cursor.Default;
       CheckBox.Enabled = true;
    }
