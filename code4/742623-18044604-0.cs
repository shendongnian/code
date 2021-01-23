    private void CheckTextBoxesName(Control root){
        foreach(Control c in root.Controls){
            if(c is TextBox) MessageBox.Show(c.Name);
            CheckTextBoxesName(c);
        }
    }
    //Note that, if your form has a TabControl, it's a little particular to add more code, otherwise, it's almost OK with the code above.
