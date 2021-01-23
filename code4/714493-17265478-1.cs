        private void button1_Click(object sender, EventArgs e)
        {            
            foreach (string s in System.IO.File.ReadAllLines("Contacts.txt"))
                    listBox1.Items.Add(s);
        }
