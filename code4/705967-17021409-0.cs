    private void Transfer_Click(object sender, EventArgs e)
        {
            File.Copy(textBox1.Text, Path.Combine(textBox2.Text, Path.ChangeExtension(textBox3.Text, Path.GetExtension(textBox1.Text)));
            label2.Text = "File Transfer Succeeded";
        }
