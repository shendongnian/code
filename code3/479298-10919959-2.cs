    private void OnProcessExited(object sender, EventArgs e)
            {
                if (_process != null)
                {
                    Thread.Sleep(2000); 
                    _process.OutputDataReceived -= OnOutputDataReceived;
                    _process.ErrorDataReceived -= OnErrorDataReceived;
                    _process.OutputDataReceived += OnOutputDataReceived;
                    _process.ErrorDataReceived += OnErrorDataReceived;                
                    _process.Start();                       
                }
            }
