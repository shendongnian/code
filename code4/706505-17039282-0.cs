    //Here is your RadioButton CheckedChanged event handler to change to image accordingly.
    private void rb_CheckedChanged(object sender, EventArgs e){
       RadioButton button = sender as RadioButton;
       button.Image = button.Checked ? Properties.Resources.CheckedImage : Properties.Resources.UncheckedImage;
    }
