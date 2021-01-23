    Dictionary<string, Image> nameAndImg = new Dictionary<string, Image>()
    {
        {"pic1",  Properties.Resources.pic1},
        {"pic2",  Properties.Resources.pic2}
        //and so on...
    };
    private void button1_Click(object sender, EventArgs e)
    {
        string name = textBox1.Text;
        if (nameAndImg.ContainsKey(name))
            pictureBox1.Image = nameAndImg[name];
        else
            MessageBox.Show("Inavlid picture name");
    }
