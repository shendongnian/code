        private void StartButtonClick(object sender, EventArgs e)
        {
            
                var t1 = new Thread(() => ProgressBar(value));
                t1.Start();
                
            }
        }
      private void ProgressBar(value)
        {
      ProgressBar.BeginInvoke(new MethodInvoker(delegate
                    {
                       ProgreeBar.value++
                    }));
     }
