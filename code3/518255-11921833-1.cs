          void Bw_DoWork(object sender, DoWorkEventArgs e)
          {
    
            //in your loop test every time Cancel flag       
            for (int i = 0; i < MyMethodGetItemcount(); i++)
            {
                MyMethod(i);//item by item
                if(yourbackgroundworker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
         }
