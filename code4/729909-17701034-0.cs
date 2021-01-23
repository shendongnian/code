    private void InsertEntries()
            {
                int itemsCount = listBox1.Items.Count > listBox1.Items.Count ?
                    listBox1.Items.Count :
                    listBox2.Items.Count;
    
                for (int i = 0; i < itemsCount; i++)
                {
                    string id = listBox1.Items[i].ToString();
                    string email = listBox2.Items[i].ToString();
                    
                    //Do your work here
                }
            }
