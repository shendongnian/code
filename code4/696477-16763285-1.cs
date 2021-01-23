    private void button2_Click(object sender, EventArgs e)
    {
         int sum = 0;
         for (int i = 1; i <= 1000; i++)
            if (i % 21 == 0 || i % 5 == 0)
                {
                    sum += i;
                    listBox2.Items.Add(i);
                }
         textBox2.Text = sum.ToString();
    }
