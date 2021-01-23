    private void searchButton_Click(object sender, EventArgs e)
            {
                clearSearchResult();
                try
                {
                    int totalItems = FirstName.Count;
                    int count = 0;
                    while (count < totalItems)
                    {
                        if (textBox6.Text == FirstName[count].ToString())
                        {
                            listBox1.Items.Add(FirstName[count].ToString());
                            count = 100;
                        }
                        else
                        {
                            count++;
                        }
