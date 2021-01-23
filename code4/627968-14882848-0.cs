    HashSet<int> hs = new HashSet<int>();
        private void savedataonhashSet_Click(object sender, EventArgs e)
        {
            hs.Add(Convert.ToInt16(textBox1.Text));
       }
        private void checkduplicatevalue_Click(object sender, EventArgs e)
        {
            if (hs.Contains(00))          
                     
            {
                MessageBox.Show("it is");
            }
            else
            {
                MessageBox.Show("not there");
            }
        }
