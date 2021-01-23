    private void button1_Click(object sender, EventArgs e)
        {
            String fileName = "d:\\Drops.txt";
            StreamReader streamReader = new StreamReader(fileName);
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear(); 
            dataGridView1.Columns.Add("Head","Head");
            dataGridView1.Columns.Add("npcID", "npcID");
            dataGridView1.Columns.Add("itemName", "itemName");
            dataGridView1.Columns.Add("itemID", "itemID");
            dataGridView1.Columns.Add("itemAmount", "itemAmount");
            dataGridView1.Columns.Add("itemRarity", "itemRarity");
          
            string itemhead = "Not Found";
            while (!streamReader.EndOfStream)
            {
                string currentLine = streamReader.ReadLine();
                if (Regex.IsMatch(currentLine, @"^\d+\s\w+\s\d+\s\d+\s\d+?\s*?$"))
                {
                    List<string> s = new List<string>();
                    s.Add(itemhead);
                    s.AddRange(currentLine.Split(' '));
                    
                    dataGridView1.Rows.Add(s.ToArray());
                    dataGridView1.Refresh();
                }
                else if(Regex.IsMatch(currentLine,@"\[[^/]*\]"))
                {
                    itemhead = Regex.Match(currentLine, @"\[([^/]*)\]").Groups[0].Value;
                }
               
            }
            streamReader.Close();
        }
