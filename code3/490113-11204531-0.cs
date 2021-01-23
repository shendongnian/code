        listBox1.Items.Add("No Of Items=" + (_server.Q.NoOfItem / 2).ToString());
        listBox2.Items.Add("No Of Items=" + (_server.Q.NoOfItem / 2).ToString());
        for (int i = 0; i <= _server.Q.NoOfItem - 1; i++)
        {
            if (i <= (_server.Q.NoOfItem / 2))
            {
                listBox1.Items.Add(_server.Q.ElementAtBuffer(i).ToString());
            }
            else 
            {
                String words = _server.Q.ElementAtBuffer(i).ToString();
                listBox2.Items.Add(words.Split(new char[] { '[', ']', ' ' }));
            }
        }
