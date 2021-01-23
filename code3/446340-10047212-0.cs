        private delegate void InsertIntoListDelegate(string email);
        public void InsertIntoList(string email)
        {
            if(InvokeRequired)
            {
                Invoke(new InsertIntoListDelegate(InsertIntoList), email);
            }
            else
            {
                f1.listView1.Items.Add(email);
                f1.listView1.Refresh();
            }
        }
