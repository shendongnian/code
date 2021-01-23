        foreach (var pair in music)
        {
            listBox1.Items.Add(pair.Key);
            //listBox2.Items.Add(pair.Value.Onloan);
            Book b = pair.Value;
            listBox3.Items.Add(b.MEM);
        }
