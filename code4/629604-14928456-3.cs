     private void button1_Click(object sender, EventArgs e)
        {
            List<string[]> testList2 = new List<string[]>();
    
            String[] text = { textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text };
            testList2.Add(text);
    
            textBox5.Text = testList2.Count.ToString();
    
            foreach (string[] list1 in testList2)
            {
                foreach (string list2 in list1)
                {
                    textBox6.AppendText(list2);
                }
            }
            
            for (int i = 0; i < testList2.Count; i++)
            {
                for (int j = 0; j < i; j++)
                {
                    textBox7.AppendText(testList2[i][j]);
                }
            }
        }
    }
    
