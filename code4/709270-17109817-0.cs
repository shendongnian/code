    private void rb_MouseHover(Object sender, EventArgs e)
    {
        switch ((Int32)((Object)sender).Tag)
        {
            case 0:
                txt_Ajuda.Text = "Text for radio button 0";
            case 1:
                txt_Ajuda.Text = "Text for radio button 1";
            //etc...
        }
    }
    private void rb_MouseLeave(Object sender, EventArgs e)
    {
        switch ((Int32)((Object)sender).Tag)
        {
            case 0:
                txt_Ajuda.Text = "Original for radio button 0";
            case 1:
                txt_Ajuda.Text = "Original for radio button 1";
            //etc...
        }
    }
