    private void button3_Click(object sender, EventArgs e)
    {
        node1.name = textBox2.Text;
        for (int i = 0; i < k; i++)
        {
            TextBox txtBox = (TextBox)groupBox2.FindControl("text" + (i + 1));
            if (txtBox != null)
            {
                node1.array[i] = txtBox.Text;
            }
        }
    }
