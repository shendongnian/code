       private void count_secs()
        {
             var frm = new Form1(); //create instance
             frm.Show(); // show form
    
            while (!stopThread)
            {
                if (stopThread)
                {
                    break;
                }
                num2++;                      // increment counter
    
                //use form instance
                frm.ShowValue(num2);       // display the counter value in the main Form
                try
                {
                    Thread.Sleep(1000);      // wait 1 sec.
                }
                catch (ThreadInterruptedException)
                {
                    if (stopThread)
                    {
                        break;
                    }
                }
            }
