       private void Btn_run_Click(object sender, EventArgs e)
        {
           if (run1.ThreadState == System.Threading.ThreadState.Aborted)
             {
                try
                {
                    myResetEvent.Reset();
                }
                catch (Exception ex)
                 {
                     throw new Exception("Exception message:" + ex.Message);
                  }
              }
               else
                {
                   try
                      {
                        myResetEvent.Set();
                       }
                       catch (Exception ex)
                        {
                         throw new Exception("Exception message:" + ex.Message);
                       }
               }
        }
