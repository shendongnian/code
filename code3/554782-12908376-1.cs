                if(dictionary.ContainsKey(item))
                {
                    MessageBox.Show("Retrieving" + item.ToString());
                }
                else
                {
                    MessageBox.Show("Value not found!");
                    return null;
                }
