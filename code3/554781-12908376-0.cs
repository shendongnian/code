            try
            {
                if(dictionary.ContainsKey(item))
                {
                    MessageBox.Show("Retrieving" + item.ToString());
                }
            }
            catch(KeyNotFoundException)
            {
                MessageBox.Show("Value not found!");
                return null; 
            }
