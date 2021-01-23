    txtBox.Enter += new System.EventHandler(Enter);
    txtBox.Leave+= new System.EventHandler(Leave);
    private void Enter(object sender, EventArgs e)
    {
        if (txtBox.Text == "Enter Text")
        {
            txtBox.Text = string.Empty;
        }
    }
