    class MyClass {
    
        public delegate void updateUIDelegate(bool refresh);
        public delegate void asyncCallback();            
    
        private void butOK_Click(object sender, EventArgs e)
        {
            butOK.Enabled = false;
            test(new asyncCallback(callback));
        }
    
        public void updateUI(bool refresh)
        {
            // long function....doing 10s
        }
    
        public void callback()
        {
            butOK.Enabled = true;
        }
    
        public void test(asyncCallback callbackMethod)
        {
            updateUIDelegate del = new updateUIDelegate(updateUI);
            del.BeginInvoke(true, null, null);
            
            if(callbackMethod != null) callback();
        }
    }
