        public void AddMessageAsync(string message, int icon)
        {
            Action<string, int> handler = (aMessage, imageIndex) =>
                listView1.Items.Add("someMessage" + aMessage, imageIndex);
            BeginInvoke(handler, message, icon);
        }
