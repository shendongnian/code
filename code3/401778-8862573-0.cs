    class Checks
    {
        private string hostname2;
        public Checks(string hostname2)
        {
           this.hostname2 = hostname2; // assign to member
        }
        public void Testing()
        {
            MessageBox.Show(hostname2);
        }
    }
