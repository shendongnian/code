    private void btn_convert_Click(object sender, EventArgs e)
    {
        if ((textBox1.Text == "") && (textBox2.Text == ""))
        {
            MessageBox.Show("Please specify input and output");
        }
        StringBuilder csvFile = new StringBuilder();
        string temp = "";
        string[] file = File.ReadAllLines(textBox1.Text);
        List<int> idList = new List<int>();
        foreach (string line in file)
        {
            string[] cols = line.Split('\t');
            if (cols.Length > 0)
            {
                int colId = -1;
                if (int.TryParse(cols[0], out colId))
                {
                    if (idList.contains(colId))
                    {
                        continue;
                    }
                    idList.Add(colId);
                }
            }
            if ((line.Contains(DateTime.Now.ToString("MM/dd/yyyy"))) && (line.Contains("\tAU\t")))
            {
                if (line.Contains("\t"))
                {
                    temp = line.Replace("\t", ",");
                    csvFile.Append(temp + "\r\n");
                    continue;
                }
                csvFile.Append(line + "\r\n");
            }
        }
        File.WriteAllText((textBox2.Text + "\\test.csv"), csvFile.ToString());
        MessageBox.Show("CSV file successfully created at the following location :\n" + textBox2.Text);
    }
