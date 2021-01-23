        public object RetrieveItemRun(int item)
        {
            object result;
            if (dictionary.TryGetValue(item, out result))
            {
                MessageBox.Show("Retrieving" + item);
            }
            return result;
        }
