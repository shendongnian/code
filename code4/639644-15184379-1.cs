    private void button1_Click(object sender, EventArgs e)
    {
        string[] lines = File.ReadAllLines("D:\\out.txt");
        foreach (var line in lines)
        {
            var data = line.Split(new[] { ',' }, 4);
            int posId = int.Parse(data[0].Trim());
            double pos = double.Parse(data[1].Trim());
            double neg = double.Parse(data[2].Trim());
            string word = data[3].Trim();
            StoreRecord(posId, pos, neg, word);
        }
    }
    private void StoreRecord(int posId, double pos, double neg, string word)
    {
        var conStr = "server=localhost; database=zahid; password=zia; User Id=root;";
        using (var connection = new MySqlConnection(conStr)) 
        using (var command = connection.CreateCommand())
        {
            connection.Open();
            command.CommandText = 
            @"INSERT INTO score 
                (POS_ID, Pos, Neg, Word) 
              VALUES 
                (@posId, @pos, @neg, @word)";
            command.Parameters.AddWithValue("@posId", posId);
            command.Parameters.AddWithValue("@pos", pos);
            command.Parameters.AddWithValue("@neg", neg);
            command.Parameters.AddWithValue("@word", word);
            command.ExecuteNonQuery();
        }
    }
