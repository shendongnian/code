        listBox1.Items.Clear();
        listBox1.Items.Add("No Of Items=" + _server.Q.NoOfItem.ToString());
        listBox2.Items.Add("No Of Items=" + _server.Q.NoOfItem.ToString());
        for (int i = 0; i <= _server.Q.NoOfItem - 1; i++)
        {
            listBox1.Items.Add(_server.Q.ElementAtBuffer(i).ToString());
            String words = _server.Q.ElementAtBuffer(i).ToString();
            string[] arr = words.Split(new char[] { '[', ']', ' ' });
            foreach (string word in arr)
                listBox2.Items.Add(word);
        }
