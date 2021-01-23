    int id;
    if(int.TryParse(textbox.Text, out id)
    {
       //Do something
    }
    else
    {
        MessageBox.Show(textbox.Text);
    }
