    private void butns_Click(object sender, EventArgs e)
    {
        Button butns = sender as Button;
        string btnName = butns.Name;
        //Get the integer part from button name... as the integer part of button and textbox is same.
        string Id = btnName.SubString(3,btnName.Length);
        TextBox txts = sender as TextBox;
        txts.Name = "txt" + Id;
        listBox2.Items.Add("text values " + txts.Text.ToString());
    }
