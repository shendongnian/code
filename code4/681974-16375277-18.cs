	startButton.Enabled = false;
	var task = Task.Factory.
			        StartNew(() =>
				        {
					        foreach (var x in Enumerable.Range(1, 10))
					        {
						        var progress = x*10;
						        Thread.Sleep(500); // fake work
						        BeginInvoke((Action) delegate { 
						           progressBar1.Value = progress; 
						        });
					        }
				        }, TaskCreationOptions.LongRunning)
			        .ContinueWith(t =>
				        {
					        startButton.Enabled = true;
					        progressBar1.Value = 0;
				        });
