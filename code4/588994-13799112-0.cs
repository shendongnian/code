        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            for (int index = 0; index < list.Count; index++)
            {
                listBox1.Items.Add(list[index]);
            }
            int mnr = Convert.ToInt32(textBox1.Text);
            string mnm = Convert.ToString(listBox1.Items[mnr - 1]);
            textBox2.Text = mnm;
        }
