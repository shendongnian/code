        private void StartButtonClick(object sender, EventArgs e)
        {
            
                var t1 = new Thread(() => ProgressBar(value));
                t1.Start();
                
            }
        }
      private void ProgressBar(value1)
        {
      ProgressBar.BeginInvoke(new MethodInvoker(delegate
                    {
                       ProgresBar.Value++
                    }));
     }
