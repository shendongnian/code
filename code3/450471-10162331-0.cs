    foreach (var item in items)
        {
            if (textBox1.Text = item.word)
            {
                textBox2.Text = item.translation;
            }
            else if (textBox2.Text = item.translation)
            {
                textBox1.Text = item.word;
            }
            else
            {
                label3.Text = ("not found");
            }
        }
