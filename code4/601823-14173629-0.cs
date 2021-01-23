    class NLApplicationContext : ApplicationContext 
    {
        List<Form2> _connections;  // Temp storage for now
        SynchronizationContext testS;
        
        public NLApplicationContext()
        {
            testS = SynchronizationContext.Current;
            _connections = new List<Form2>();
            
            NLServer test = new NLServer();
            test.ClientConnected += test_ClientConnected;
            test.Start();
        }
        void test_ClientConnected(object sender)
        {
            testS.Post(DisplayForm, sender);
        }
        private void DisplayForm(object sender)
        {
            Form2 newForm = new Form2((NLClient)sender);
            newForm.Show();
            _connections.Add(newForm);  //Find better storage/sorting
        }
    }
