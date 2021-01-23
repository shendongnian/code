    private void txtTextbox_KeyDown(object sender, KeyEventArgs e)
    {
        //do somthing
        if(e.KeyCode==Keys.Enter)
        {
            e.Handled=true;
            e.SuppressKeyPress=true;
        }
    }
    private void txtTextbox_KeyUp(object sender, KeyEventArgs e)
    {
        e.Handled=false;
        e.SuppressKeyPress=false;
    }
