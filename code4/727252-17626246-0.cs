    int length = 10;
    string msg;
    private void button1_Click(object sender, EventArgs e)
    {
        msg = GenerateRandomCode(ref length);
        textBox1.Text = msg;
        MessageBox.Show(msg);
    }
        public string GenerateRandomCode(ref int length)
        {
            string charPool = "ABCDEFGOPQRSTUVWXY1234567890ZabcdefghijklmHIJKLMNnopqrstuvwxyz";
            StringBuilder rs = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                rs.Append(charPool[(int)(random.NextDouble() * charPool.Length)]);
            }
            return rs.ToString();
        }
    }
