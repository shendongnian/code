    if (textBox6.Text.Trim().Length != 0)
    {
        salesmen.Add(new Salesmane() { name = textBox6.Text } );
    }
    else
    {
        MessageBox.Show("Please Input a Name");
    }
