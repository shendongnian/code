    private void Input_HP_TextChanged(object sender, EventArgs e)
    {
        int i = 0;
        if(int.TryParse(Input_HP.Text, out i))
        {
           HP = i;
        }
        else
        {
           Input_HP.Text = i.ToString();
        }
    }
