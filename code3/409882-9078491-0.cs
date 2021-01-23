    void bw_DoWork(object sender, DoWorkEventArgs e)
    {
    	CancellationTokenSource _tokenSource = new CancellationTokenSource();
    	CancellationToken _token = _tokenSource.Token;
    	
    	var urls = e.Argument as IEnumerable<string>;
    
    	_token = new CancellationToken();
    
    	if (urls == null) return;
    
    	var i = 0;
    	var a = 100 / urls.Count();
    
    	var sb = new StringBuilder();
    	var t = urls.Select(url => Task.Factory.StartNew(
                        (u) =>{
                            using (var wc = new WebClient())
                            {
                                lock (this){
                                    var s = wc.DownloadString(u.ToString());
                                    sb.AppendFormat("{1}:{0}\r\n", "", u);
                                }
                            }
                        if (Worker.CancellationPending){
                            //MAGIC HAPPENS HERE, IF BackgroundWorker IS REQUESTED
                            //TO CANCEL, WE CANCEL CancellationTokenSource
                            _tokenSource.Cancel();
                        }
                        //IF CANCELATION REQUESTED VIA CancellationTokenSource
                        //THROW EXCEPTION WHICH WILL ADD TO AggreegateException
                        _token.ThrowIfCancellationRequested();
                        //YOU CAN IGNORE FOLLOWING 2 LINES
                        i += a;
                        Worker.ReportProgress(i, u);
        }, url, _token)).ToArray();
    
    	try
    	{
    		Task.WaitAll(t);
    	}
    	catch (AggregateException age)
    	{
    		if (age.InnerException is OperationCanceledException)
    			sb.Append("Task canceled");
    	}
    	catch (Exception ex)
    	{
    		sb.Append(ex.Message);
    	}
    
    	e.Result = sb;
    }
