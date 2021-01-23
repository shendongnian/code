    void YourMethod()
    {
         WaitForm wf = new WaitForm();
         Invoke(new PleaseWaitDelegate(Launch),wf);
         bool val = BoolMethodDoWork();
         Invoke(new PleaseWaitDelegate(Close), wf);
                    if(val)
                    {
                        MessageBox.Show("Success!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                        return;
                    }
                    MessageBox.Show("Damn!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
    }
    delegate void PleaseWaitDelegate(Form form);
            void Launch(Form form)
            {
                new System.Threading.Thread(()=> form. ShowDialog()).Start();
            }
    
            void Close(Form form)
            {
                form.Close();
            }
