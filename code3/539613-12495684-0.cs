    private void dailogueOpen(TextBox textBox)
    {
        if (listBox1.SelectedItem == null)
        {
            MessageBox.Show("Please Select a form");
        }
        else
        {
            var selectedItem = (FormItems)listBox1.SelectedItem;
            var form2result = new Form2(myDataSet, selectedItem);
            var resulOfForm2 = form2result.ShowDialog();
            if (resulOfForm2 == DialogResult.OK)
            {
                textBox.Text = form2result.getValue();
            }
        }
    }
    private void button1_Click(object sender, EventArgs e)
    {
        dailogueOpen(textBox1);
    }
    private void button2_Click(object sender, EventArgs e)
    {
        dailogueOpen(textBox2);
    }
    private void button3_Click(object sender, EventArgs e)
    {
        dailogueOpen(textBox3);
    }
    private void button4_Click(object sender, EventArgs e)
    {
        dailogueOpen(textBox4);
    }
    private void button5_Click(object sender, EventArgs e)
    {
        dailogueOpen(textBox5);
    }
