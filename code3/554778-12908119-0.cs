       public object RetrieveItemRun(int item)
        {
            if (dictionary.ContainsKey(item))
            {
                MessageBox.Show("Retrieving" + item.ToString());
                return dictionary[item];
            }
            return null;
        }
