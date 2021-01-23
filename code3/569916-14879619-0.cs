      public void test()
            {
                p1.OutputDataReceived += new DataReceivedEventHandler(p1_OutputDataReceived);
            }
    
            void p1_OutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                throw new NotImplementedException();
            }
