    private void Form1Button_Clicked(object sender, EventArgs e)
    {
        Form2 f2 = new Form2();
	f2.Owner = this;
	f2.Show();
    }
    public void AddListItem(object text)
    {
        YourListBox.Items.Add(text);
    }
