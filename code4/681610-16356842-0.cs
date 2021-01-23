            //this will call your method in background
            var task = Task.Factory.StartNew(() => yourDll.YourMethodThatDoesCommunication());
            //setup delegate to invoke when the background task completes
            task.ContinueWith(t =>
                {
                    //this will execute when the background task has completed
                    if (t.IsFaulted)
                    {
                        //somehow handle exception in t.Exception
                        return;
                    }          
          
                    var result = t.Result;
                    //process result
                });
