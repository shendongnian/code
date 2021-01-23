      private void WaitForInput()
      {
          Task.Factory.StartNew(() =>
              {
                  while (!gotInput)
                  {
                      System.Threading.Thread.Sleep(1);
                  }
                  MessageBox.Show("Test");
              });
      }
