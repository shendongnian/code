    private void Button1_Click(object sender, EventArgs e)
    {
        using(Form1 frm1 = new Form1())
        {
           if(frm1.ShowDialog() != DialogResult.OK)
              return;
           UpdateText(frm1.SelectedValue);
        }
    }
    public void UpdateText(string text)
    {
        label1.Text = text;
        textBox1.Text = text;
        label1.Refresh();
    }
