    DateTime dt = DateTime.Now;
    
    string s = dt.DayOfWeek.ToString();
    for (int i = 0; i < 10; i++)
    {
        dataGridView1.Columns.Add(string.Format("col{0}", i), s);
    }
    
    for (int i = 0; i < dataGridView1.Columns.Count; i++)
    {
       string str = dataGridView1.Columns[i].HeaderText;
       if (str == "Wednesday")
       {
           dataGridView1.Columns[i].HeaderText = "fifth day of week";
       }
    }
