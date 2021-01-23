    private void button1_Click(object sender, EventArgs e)
    {
        using (var stream = File.OpenRead("D:\\out.txt"))
        using (var reader = new StreamReader(stream))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var data = line.Split(new[] { ',' }, 4);
                int posId = int.Parse(data[0].Trim());
                double pos = double.Parse(data[1].Trim());
                double neg = double.Parse(data[2].Trim());
                string word = data[3].Trim();
                StoreRecord(posId, pos, neg, word);
            }
        }
    }
