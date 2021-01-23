    private void button1_Click(object sender, EventArgs e)
    {
        string[] lines = new string[] { "555-555-1212", "I want's a lemon's.", "google.com", "1&1 Hosting" };
        string[] removables = textBox1.Text.Split(',');
        string[] newLine = new string[lines.Count()];
        int i = 0;
        foreach (string line in lines)
        {
            newLine[i] = line;
            foreach (string rem in removables)
            {
                while(newLine[i].Contains(rem))
                    newLine[i] = newLine[i].Remove(newLine[i].IndexOf(rem), rem.Length);
            }
            MessageBox.Show(newLine[i]);
            i++;
        }
    }
