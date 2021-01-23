    class myClass {
        public event EventHandler myEvent;
        
        myEvent += new EventHandler(met1);
        myEvent += new EventHandler(met2);
        myEvent += new EventHandler(met3);
        public void metN(object sender, MyCustomEventArgs e)
        {
            if(e.Cancel)
                return;
    
            // Do whatever you like
            if(<someBooleanStatement>)
            {
                e.Cancel = true;
                return;
            }
            // Do whatever you like
        }
    }
