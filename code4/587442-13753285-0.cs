    private void findLast_Click(object sender, EventArgs e)
        {
            query = textBox2.Text;
            search = File.ReadAllText(fileName).Split(new string[] { "\n", "\r\n", ":" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string k in search)
            {
                if (query == k)
                {
                    MessageBox.Show("Match");
                }
                else
                    MessageBox.Show("No Match");
            }
        }
