    private void button2_Click(object sender, EventArgs e)
    {
        List<string> tilelocation = new List<string>();
        foreach(TextBox tb in this.Controls.OfType<TextBox>().Where(r=> r.Name.StartsWith("txtDynamic"))
              titlelocation.Add(tb.Text);
     //if you want a string out of it. 
     string str = string.Join(",", titlelocation);
     MessageBox.Show(str);
    }
