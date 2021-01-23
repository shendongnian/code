    protected void Button1_Click(object sender, EventArgs e)
    {
        //code to bind your list goes here
        listaProduseBon.Add(new ProdusBon(-1, Int32.Parse(TextBox2.Text), -1, Int32.Parse (ListBox1.SelectedValue)));
    }
