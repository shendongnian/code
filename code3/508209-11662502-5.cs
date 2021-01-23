    private void button1_Click(object sender, EventArgs e) {
        string url = "...";
        var item = Item.GetFromUrl(url);
        MessageBox.Show("You found item #" + item.Id + " named " + item.Name);
        txtBoxName.Text = item.Name;
        txtBoxCat.Text = item.Category;
    }
