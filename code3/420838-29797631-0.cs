        private void button2_Click(object sender, EventArgs e)
        {
            TextBox tb = new TextBox();
            tb.Name = abc;
            tb.Text = "" + i;
            Point p = new Point(20 + i, 30 * i);
            tb.Location = p;
            this.Controls.Add(tb);
            i++;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            foreach (TextBox item in this.Controls.OfType<TextBox>())
            {
                MessageBox.Show(item.Name + ": " + item.Text + "\\n");   
            }
        }
