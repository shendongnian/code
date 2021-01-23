    private void processWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
         string code = DoLongWorkAndReturnCode();
         if (code != 0)
         {
             thow new MyCustomExecption(code);
         }
    }
    private void processWorker2_DoWork(object sender, DoWorkEventArgs e)
    {
         string code = DoAnotherLongProcessAndReturnCode(); 
         if (code != 0)
         {
             thow new MyCustomExecption(code);
         }
    }
    private void processWorkers_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if(e.Error != null)
        {
            string message;
            
            //See if it was our error
            if(e.Error.GetType() == typeOf(MyCustomExecption))
            {
                
                //Choose which error message to send
                if(sender.Equals(processWorker2))
                    message = "Error2!";
                else
                    message = "Error!";
            }
            else
            {
                //Handle other types of thrown exceptions other than the ones we sent
                message = e.Error.ToString();
            }
            
                
            //no matter what, show a dialog box and enable all buttons.
            MessageBox.Show(message);
            EnableAllButtons();
        }
        else
        {
            //Worker completed successfully. 
            //If this was called from processWorker1 call processWorker2
            
            //Here is the code that was returned from the function
            if(sender.Equals(processWorker1))
                processWorker2.RunWorkerAsync();
        }
 
    }
