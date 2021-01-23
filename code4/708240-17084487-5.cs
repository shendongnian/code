    private LoginForm form;
    private void ButtonClick(object sender, EventArgs e)
    {
        if (form != null)
        {
           if (form.Visible)
           {
               return;
           }
           
           form.Show();
        }
        else
        {
           form = new LoginForm();
           form.Show();
        }
    }
