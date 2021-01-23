    void checkBox_CheckedChanged(object sender, EventArgs e){
        CheckBox checkBox = (CheckBox)sender;
        if(checkBox.Checked){
            foreach(CheckBox c in listCheckBoxes){
                if(c.Checked && c != checkBox)
                   c.Checked = false;
            }
        }
    }
