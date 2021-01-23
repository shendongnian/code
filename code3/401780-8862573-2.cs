    class Checks
    {
        public string Hostname2 { get; set; }
        public Checks(string hostname2)
        {
           this.Hostname2 = hostname2; // assign to property
        }
        public void Testing()
        {
            MessageBox.Show(Hostname2);
        }
    }
