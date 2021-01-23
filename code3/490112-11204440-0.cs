        private void button1_Click_2(object sender, EventArgs e)
        {
            //String[] arr = new String[1];
            listBox1.Items.Clear();
            listBox1.Items.Add("No Of Items=" + _server.Q.NoOfItem.ToString());
            for (int i=0; i <= _server.Q.NoOfItem - 1; i++)
            {
                listBox1.Items.Add( _server.Q.ElementAtBuffer(i).ToString());               
            }
            String words = _server.Q.ElementAtBuffer(i).ToString();  
            listBox2.Items.Add("No Of Items=" + _server.Q.NoOfItem.ToString());
            listBox2.Items.AddRange(words.Split(new char[] { '[' , ']', ' '}));           
        }     
