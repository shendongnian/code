            List<int> integerList = new List<int>();
               
            foreach(char c in textBox1.Text)
            {
              int x = int.Parse(c.ToString());
              integerList.Add(x);
              listBox1.Items.Add(x);
            }
