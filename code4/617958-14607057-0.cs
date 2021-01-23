    private void button1_Click(object sender, EventArgs e)
    {
      button1.Enabled = false;
      using (Form2 form = new Form2())
      {
        form.ShowDialog();
      }
      button1.Enabled = true;
    }
