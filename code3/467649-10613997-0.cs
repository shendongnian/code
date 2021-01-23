    new Action(() => {
                        if (_progressBar == null){
                            if (Debugger.IsAttached){
                                Debugger.Break();
                            } else {
                                Debug.Fail("_progressbar is null!");
                            }
                         } else {
                           _progressBar.Close();
                         }
                      });
