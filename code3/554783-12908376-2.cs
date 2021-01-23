            try
            {
                if(dictionary.ContainsKey(item))
                {
                    MessageBox.Show("Retrieving" + item.ToString());
                }            
                else
                {
                    MessageBox.Show("Value not found!");
                    return null;
                }
            }
            catch(KeyNotFoundException)
            {
                MessageBox.Show("Null key!");
                return null; 
            }
