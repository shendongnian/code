        public void checkStock()
        {
            foreach (var listBoxItem in listBox1.Items)
            {
                // use the currently iterated list box item
                MessageBox.Show(string.Format("{0} is not in stock!",listBoxItem.ToString()));
                
            }
        }
