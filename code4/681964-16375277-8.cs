	startButton.Enabled = false;
	var pr = new Progress<int>();
	pr.ProgressChanged += (o, i) => progressBar1.Value = i;
	await Task.Factory.
			    StartNew(() =>
				            {
					            foreach (var x in Enumerable.Range(1, 10))
					            {
						            Thread.Sleep(500); // fake work
						            ((IProgress<int>) pr).Report(x*10);
					            }
				            }, TaskCreationOptions.LongRunning);
	startButton.Enabled = true;
	progressBar1.Value = 0;
