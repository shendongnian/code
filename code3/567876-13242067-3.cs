     MyAsyncClass myClass = null;
        private void button2_Click(object sender, EventArgs e)
        {
            myClass = new MyAsyncClass();
            myClass.NotifyCompleteEvent += new MyAsyncClass.NotifyComplete(myClass_NotifyCompleteEvent);
            //here I start the job inside working class...
            myClass.Start();
        }
        //here my class is notified from working class when job is completed...
        delegate void myClassDelegate(string message);
        void myClass_NotifyCompleteEvent(string message)
        {
            if (this.InvokeRequired)
            {
                Delegate d = new myClassDelegate(myClass_NotifyCompleteEvent);
                this.Invoke(d, new object[] { message });
            }
            else
            {
                MessageBox.Show(message);
            }
        }
