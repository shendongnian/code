        using System.Linq;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var textBytes = Encoding.UTF8.GetBytes(textBox1.Text);
            if (Encoding.UTF8.GetCharCount(textBytes) != Encoding.UTF8.GetByteCount(textBox1.Text))
            {
                // has double chars
                textBox1.Text = Encoding.UTF32.GetString(Encoding.UTF32.GetBytes(textBox1.Text).Take(6 * 2).ToArray());
            }
            else
            {
                textBox1.Text = Encoding.UTF8.GetString(textBytes.Take(6).ToArray());
            }
        }
